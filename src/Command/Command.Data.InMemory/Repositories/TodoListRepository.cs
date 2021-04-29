using $ext_safeprojectname$.Command.Application.Repositories;
using $ext_safeprojectname$.Command.Domain.BaseComponents;
using $ext_safeprojectname$.Command.Domain.TodoLists;
using $ext_safeprojectname$.Command.Domain.TodoLists.DomainEvents;
using $ext_safeprojectname$.Command.Domain.TodoLists.ValueObjects;
using Microsoft.Extensions.Caching.Memory;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace $safeprojectname$.Repositories
{
    // This is a Fake in memory repository
    // If you want to use a concrete datastore, create a new *.Data project,
    // implement the repository interfaces in your new project
    // then remove the injections from this one in the *.Dependencies project
    public class TodoListRepository : ITodoListRepository
    {
        private const string cacheKey = "TodoList";
        private readonly List<dynamic> dataStore;
        private readonly Dictionary<TodoListId, List<IDomainEvent>> eventStore;

        public TodoListRepository(IMemoryCache memoryCache)
        {
            dataStore = GetData(memoryCache);
            eventStore = new Dictionary<TodoListId, List<IDomainEvent>>();
        }

        public Task<TodoList> Get(TodoListId id)
        {
            return Task.Run(() =>
            {
                if (EVENTSOURCING.ISACTIVE) return GetFromEvents(id);

                return dataStore.FirstOrDefault(m => m.Id == id) as TodoList;
            });
        }

        public Task<bool> Insert(TodoList aggregate)
        {
            return Task.Run(() =>
            {
                if (EVENTSOURCING.ISACTIVE) StoreEvents(aggregate);

                var todoList = dataStore.FirstOrDefault(m => m.Id == aggregate.Id);

                if (todoList != null) return false;

                dataStore.Add(aggregate);

                return true;
            });
        }

        public Task<bool> Update(TodoList aggregate)
        {
            return Task.Run(() =>
            {
                if (EVENTSOURCING.ISACTIVE) StoreEvents(aggregate);

                var todoList = dataStore.FirstOrDefault(m => m.Id == aggregate.Id);

                if (todoList == null) return false;

                dataStore.Remove(todoList);

                dataStore.Add(aggregate);

                return true;
            });
        }

        #region Private Methods

        private List<dynamic> GetData(IMemoryCache memoryCache)
        {
            return memoryCache.GetOrCreate(cacheKey, (entry) =>
            {
                return new List<dynamic>();
            });
        }

        private void StoreEvents(TodoList aggregate)
        {
            if (!eventStore.ContainsKey(aggregate.Id)) eventStore.Add(aggregate.Id, new List<IDomainEvent>());
            eventStore[aggregate.Id].AddRange(aggregate.Events);
        }

        private TodoList GetFromEvents(TodoListId id)
        {
            if (!eventStore.ContainsKey(id)) return null;

            var domainEvents = eventStore[id];

            // We consider the first event as the created event in this repository
            // In a production system, multiple checks should be done
            var createdEvent = domainEvents.First() as TodoListCreatedEvent;

            var todoList = TodoList.CreateFromEvent(createdEvent);

            foreach (var domainEvent in domainEvents)
            {
                if (domainEvent is TodoListCreatedEvent) continue;
                todoList.Apply(domainEvent);
            }

            return todoList;
        }

        #endregion
    }
}
