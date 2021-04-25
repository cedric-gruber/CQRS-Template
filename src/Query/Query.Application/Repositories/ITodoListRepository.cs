using $safeprojectname$.Models.TodoListModels.Projections;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace $safeprojectname$.Repositories
{
    public interface ITodoListRepository
    {
        Task<IEnumerable<AllTodosProjection>> GetAllTodos();

        Task<IEnumerable<AllTodoListsProjection>> GetAllTodoLists();

        Task<IEnumerable<TodosByListProjection>> GetTodosByList(Guid listId);
    }
}
