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
    public class CreateTodoCommandHandler : IRequestHandler<CreateTodoCommand, CreateTodoResponse>
    {
        private readonly ITodoListRepository repository;
        private readonly ITodoFileService fileService;

        public CreateTodoCommandHandler(ITodoListRepository repository, ITodoFileService fileService)
        {
            this.repository = repository;
            this.fileService = fileService;
        }

        public async Task<CreateTodoResponse> Handle(CreateTodoCommand request, CancellationToken cancellationToken)
        {
            if (string.IsNullOrWhiteSpace(request.Content)) throw new EmptyParameterException("The todo content cannot be empty.");

            var todoListId = new TodoListId(request.TodoListId);
            var todoName = new TodoName(request.TodoName);

            var aggregateRoot = await repository.Get(todoListId);

            if (aggregateRoot == null) throw new NotFoundException($"The todo list with id {request.TodoListId} doesn't exist.");

            var aggregate = aggregateRoot.AddTodo(todoName);

            fileService.AddOrUpdateFile(aggregate, request.Content);

            await repository.Update(aggregateRoot);

            return new CreateTodoResponse { Aggregate = aggregate };
        }
    }
}
