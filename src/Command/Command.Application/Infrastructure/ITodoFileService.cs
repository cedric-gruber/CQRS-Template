using $ext_safeprojectname$.Command.Domain.TodoList;

namespace $safeprojectname$.Infrastructure
{
    public interface ITodoFileService
    {
        void AddOrUpdateFile(Todo todo, string content);

        void DeleteFile(Todo todo);
    }
}
