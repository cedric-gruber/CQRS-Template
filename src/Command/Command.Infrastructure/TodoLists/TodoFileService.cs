using $ext_safeprojectname$.Command.Application.Infrastructure.TodoLists;
using $ext_safeprojectname$.Command.Domain.TodoLists;
using $ext_safeprojectname$.Common.Infrastructure.FileSystem;

namespace $safeprojectname$.TodoLists
{
    public class TodoFileService : ITodoFileService
    {
        private readonly IFileService fileService;

        public TodoFileService(IFileService fileService)
        {
            this.fileService = fileService;
        }

        public void AddOrUpdateFile(Todo todo, string fileContent)
        {
            string fileName = GetFileName(todo);

            if (fileService.FileExist(fileName))
                fileService.DeleteFile(fileName);

            fileService.AddFile(fileName, fileContent);
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
