using $safeprojectname$.Commands.TodoLists;
using $safeprojectname$.Commands.TodoLists.Responses;
using $safeprojectname$.Infrastructure.TodoLists;
using $safeprojectname$.Repositories;
using $ext_safeprojectname$.Command.Domain.TodoLists.ValueObjects;
using $ext_safeprojectname$.Common.Exceptions;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace $safeprojectname$.CommandHandlers.TodoLists
{
    public class RemoveTodoCommandHandler : IRequestHandler<RemoveTodoCommand, RemoveTodoResponse>
    {
        private readonly ITodoListRepository repository;
        private readonly ITodoFileService fileService;

        public RemoveTodoCommandHandler(ITodoListRepository repository, ITodoFileService fileService)
        {
            this.repository = repository;
            this.fileService = fileService;
        }

        public async Task<RemoveTodoResponse> Handle(RemoveTodoCommand request, CancellationToken cancellationToken)
        {
            var todoListId = new TodoListId(request.TodoListId);
            var todoId = new TodoId(request.TodoId);

            var todoList = await repository.Get(todoListId);

            if (todoList == null) throw new NotFoundException($"The todo list with id {request.TodoListId} doesn't exist.");

            var todo = todoList.RemoveTodo(todoId);

            fileService.DeleteFile(todo);

            await repository.Update(todoList);

            return new RemoveTodoResponse { Aggregate = todo };
        }
    }
}
