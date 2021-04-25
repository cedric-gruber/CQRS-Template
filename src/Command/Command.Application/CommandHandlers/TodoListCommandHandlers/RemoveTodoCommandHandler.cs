using MediatR;
using $safeprojectname$.Commands.TodoListCommands;
using $safeprojectname$.Commands.TodoListResponses;
using $safeprojectname$.Infrastructure;
using $safeprojectname$.Repositories;
using $ext_safeprojectname$.Command.Domain.TodoList.ValueObjects;
using $ext_safeprojectname$.Common.Exceptions;
using System.Threading;
using System.Threading.Tasks;

namespace $safeprojectname$.CommandHandlers.TodoListCommandHandlers
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

            var aggregateRoot = await repository.Get(todoListId);

            if (aggregateRoot == null) throw new NotFoundException($"The todo list with id {request.TodoListId} doesn't exist.");

            var aggregate = aggregateRoot.RemoveTodo(todoId);

            fileService.DeleteFile(aggregate);

            await repository.Update(aggregateRoot);

            return new RemoveTodoResponse { Aggregate = aggregate };
        }
    }
}
