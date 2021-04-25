using MediatR;
using $safeprojectname$.Commands.TodoListCommands;
using $safeprojectname$.Commands.TodoListResponses;
using $safeprojectname$.Repositories;
using $ext_safeprojectname$.Command.Domain.TodoList.ValueObjects;
using $ext_safeprojectname$.Common.Exceptions;
using System.Threading;
using System.Threading.Tasks;

namespace $safeprojectname$.CommandHandlers.TodoListCommandHandlers
{
    public class ChangeTodoListNameCommandHandler : IRequestHandler<ChangeTodoListNameCommand, ChangeTodoListNameResponse>
    {
        private readonly ITodoListRepository repository;

        public ChangeTodoListNameCommandHandler(ITodoListRepository repository)
        {
            this.repository = repository;
        }

        public async Task<ChangeTodoListNameResponse> Handle(ChangeTodoListNameCommand request, CancellationToken cancellationToken)
        {
            var todoListId = new TodoListId(request.TodoListId);
            var todoListName = new TodoListName(request.TodoListName);

            var aggregateRoot = await repository.Get(todoListId);

            if (aggregateRoot == null) throw new NotFoundException($"The todo list with id {request.TodoListId} doesn't exist.");

            aggregateRoot.ChangeName(todoListName);

            await repository.Update(aggregateRoot);

            return new ChangeTodoListNameResponse { Aggregate = aggregateRoot };
        }
    }
}
