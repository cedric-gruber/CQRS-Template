using $safeprojectname$.Models.TodoLists.ViewModels;

namespace $safeprojectname$.Infrastructure.TodoLists
{
    public interface ITodoFileService
    {
        public string GetFileContent(AllTodoListsViewModel projection);

        public string GetFileContent(TodosByListViewModel projection);
    }
}
