using $ext_safeprojectname$.Command.Domain.TodoList;
using $ext_safeprojectname$.Command.Domain.TodoList.ValueObjects;
using System.Threading.Tasks;

namespace $safeprojectname$.Repositories
{
    public interface ITodoListRepository
    {
        Task<TodoList> Get(TodoListId id);

        Task<bool> Insert(TodoList aggregate);

        Task<bool> Update(TodoList aggregate);
    }
}
