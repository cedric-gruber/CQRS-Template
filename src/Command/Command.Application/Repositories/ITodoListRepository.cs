using $ext_safeprojectname$.Command.Domain.TodoLists;
using $ext_safeprojectname$.Command.Domain.TodoLists.ValueObjects;
using System.Threading.Tasks;

namespace $safeprojectname$.Repositories
{
    public interface ITodoListRepository
    {
        Task<TodoList> Get(TodoListId id);

        Task<bool> Save(TodoList aggregate);
    }
}
