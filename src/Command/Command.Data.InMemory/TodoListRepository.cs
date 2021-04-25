using Microsoft.Extensions.Caching.Memory;
using $ext_safeprojectname$.Command.Application.Repositories;
using $ext_safeprojectname$.Command.Domain.BaseComponents;
using $ext_safeprojectname$.Command.Domain.TodoList;
using $ext_safeprojectname$.Command.Domain.TodoList.DomainEvents;
using $ext_safeprojectname$.Command.Domain.TodoList.ValueObjects;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace $safeprojectname$
{
    public class TodoListRepository : ITodoListRepository
    {
        private const string cacheKey = "TodoList";
        private readonly IMemoryCache memoryCache;
        private readonly List<dynamic> dataStore;
        private readonly Dictionary<TodoListId, List<IDomainEvent>> eventStore;

        public TodoListRepository(IMemoryCache memoryCache)
        {
            this.memoryCache = memoryCache;
            dataStore = GetData();
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

                var item = dataStore.FirstOrDefault(m => m.Id == aggregate.Id);

                dataStore.Add(aggregate);

                return true;
            });
        }

        public Task<bool> Update(TodoList aggregate)
        {
            return Task.Run(() =>
            {
                if (EVENTSOURCING.ISACTIVE) StoreEvents(aggregate);

                var item = dataStore.FirstOrDefault(m => m.Id == aggregate.Id);

                if (item == null) return false;

                dataStore.Remove(item);

                dataStore.Add(aggregate);

                return true;
            });
        }

        #region Private Methods

        private List<dynamic> GetData()
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

            var createdEvent = domainEvents.FirstOrDefault() as TodoListCreatedEvent;

            var result = TodoList.CreateFromEvent(createdEvent);

            foreach (var domainEvent in domainEvents)
            {
                if (domainEvent is TodoListCreatedEvent) continue;
                result.Apply(domainEvent);
            }

            return result;
        }

        #endregion
    }
}
