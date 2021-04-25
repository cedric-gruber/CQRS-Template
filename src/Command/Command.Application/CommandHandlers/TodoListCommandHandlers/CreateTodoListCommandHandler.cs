using MediatR;
using $safeprojectname$.Commands.TodoListCommands;
using $safeprojectname$.Commands.TodoListResponses;
using $safeprojectname$.Repositories;
using $ext_safeprojectname$.Command.Domain.TodoList;
using $ext_safeprojectname$.Command.Domain.TodoList.ValueObjects;
using System.Threading;
using System.Threading.Tasks;

namespace $safeprojectname$.CommandHandlers.TodoListCommandHandlers
{
    public class CreateTodoListCommandHandler : IRequestHandler<CreateTodoListCommand, CreateTodoListResponse>
    {
        private readonly ITodoListRepository repository;

        public CreateTodoListCommandHandler(ITodoListRepository repository)
        {
            this.repository = repository;
        }

        public async Task<CreateTodoListResponse> Handle(CreateTodoListCommand request, CancellationToken cancellationToken)
        {
            var todoListName = new TodoListName(request.TodoListName);

            var aggregateRoot = TodoList.Create(todoListName);

            await repository.Insert(aggregateRoot);

            return new CreateTodoListResponse { Aggregate = aggregateRoot };
        }
    }
}
