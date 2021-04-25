using $ext_safeprojectname$.Command.Application.Infrastructure;
using $ext_safeprojectname$.Command.Domain.TodoList;
using $ext_safeprojectname$.Common.Infrastructure.FileSystem;

namespace $safeprojectname$
{
    public class TodoFileService : ITodoFileService
    {
        private readonly IFileService fileService;

        public TodoFileService(IFileService fileService)
        {
            this.fileService = fileService;
        }

        public void AddOrUpdateFile(Todo todo, string content)
        {
            string fileName = GetFileName(todo);

            if (fileService.FileExist(fileName))
                fileService.DeleteFile(fileName);

            fileService.AddFile(fileName, content);
        }

        public void DeleteFile(Todo todo)
        {
            string fileName = GetFileName(todo);

            if (fileService.FileExist(fileName))
                fileService.DeleteFile(fileName);
        }

        private string GetFileName(Todo todo)
        {
            return $"Todo_{todo.Id.Value}.txt";
        }
    }
}
