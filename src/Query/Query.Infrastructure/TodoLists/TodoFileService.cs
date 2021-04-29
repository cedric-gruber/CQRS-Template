using $ext_safeprojectname$.Common.Exceptions;
using $ext_safeprojectname$.Common.Infrastructure.FileSystem;
using $ext_safeprojectname$.Query.Application.Infrastructure.TodoLists;
using $ext_safeprojectname$.Query.Application.Models.TodoLists.ViewModels;
using System;

namespace $safeprojectname$.TodoLists
{
    public class TodoFileService : ITodoFileService
    {
        private readonly IFileService fileService;

        public TodoFileService(IFileService fileService)
        {
            this.fileService = fileService;
        }

        public string GetFileContent(AllTodoListsViewModel projection)
        {
            var fileName = GetFileName(projection.Id);

            if (!fileService.FileExist(fileName)) throw new NotFoundException($"The file associated with the todo {projection.Id} doesn't exist.");

            return fileService.ReadFile(fileName);
        }

        public string GetFileContent(TodosByListViewModel projection)
        {
            var fileName = GetFileName(projection.Id);

            if (!fileService.FileExist(fileName)) throw new NotFoundException($"The file associated with the todo {projection.Id} doesn't exist.");

            return fileService.ReadFile(fileName);
        }

        private string GetFileName(Guid todoId)
        {
            return $"Todo_{todoId}.txt";
        }
    }
}
