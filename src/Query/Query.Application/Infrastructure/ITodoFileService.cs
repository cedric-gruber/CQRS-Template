using $safeprojectname$.Models.TodoListModels.ViewModels;

namespace $safeprojectname$.Infrastructure
{
    public interface ITodoFileService
    {
        public string GetFileContent(AllTodoListsViewModel projection);

        public string GetFileContent(TodosByListViewModel projection);
    }
}
