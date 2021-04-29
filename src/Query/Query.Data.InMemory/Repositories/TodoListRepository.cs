using $ext_safeprojectname$.Query.Application.Models.TodoLists.Projections;
using $ext_safeprojectname$.Query.Application.Repositories;
using Microsoft.Extensions.Caching.Memory;
using System;
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
        private readonly IMemoryCache memoryCache;
        private readonly List<dynamic> dataStore;

        public TodoListRepository(IMemoryCache memoryCache)
        {
            this.memoryCache = memoryCache;
            this.dataStore = GetData();
        }

        public Task<IEnumerable<AllTodosProjection>> GetAllTodos()
        {
            return Task.Run(() =>
            {
                List<AllTodosProjection> result = new List<AllTodosProjection>();

                foreach (var todoList in dataStore)
                {
                    foreach (var todo in todoList.Todos)
                    {
                        result.Add(new AllTodosProjection
                        {
                            Id = todo.Id.Value,
                            Name = todo.Name.Value,
                            ListName = todoList.Name.Value
                        });
                    }
                }

                return result.AsEnumerable();
            });

        }

        public Task<IEnumerable<AllTodoListsProjection>> GetAllTodoLists()
        {
            return Task.Run(() =>
            {
                return dataStore.Select(m => new AllTodoListsProjection { Name = m.Name.Value, Id = m.Id.Value, NumberOfTodos = m.Todos.Count });
            });
        }

        public Task<IEnumerable<TodosByListProjection>> GetTodosByList(Guid listId)
        {
            return Task.Run(() =>
            {
                var result = new List<TodosByListProjection>();

                var todos = dataStore.FirstOrDefault(m => m.Id.Value == listId)?.Todos;

                if (todos == null) return result;

                foreach (var todo in todos)
                    result.Add(new TodosByListProjection
                    {
                        Id = todo.Id.Value,
                        Name = todo.Name.Value,
                        IsCompleted = todo.Completed
                    });

                return result.AsEnumerable();
            });
        }

        private List<dynamic> GetData()
        {
            return memoryCache.GetOrCreate(cacheKey, (entry) =>
            {
                return new List<dynamic>();
            });
        }

    }
}
