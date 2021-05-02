using $ext_safeprojectname$.Command.Domain.TodoLists;

namespace $safeprojectname$.Infrastructure.TodoLists
{
    public interface ITodoFileService
    {
        void SaveFile(Todo todo, string content);

        void DeleteFile(Todo todo);
    }
}
