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
    public class ChangeTodoNameCommandHandler : IRequestHandler<ChangeTodoNameCommand, ChangeTodoNameResponse>
    {
        private readonly ITodoListRepository repository;

        public ChangeTodoNameCommandHandler(ITodoListRepository repository)
        {
            this.repository = repository;
        }

        public async Task<ChangeTodoNameResponse> Handle(ChangeTodoNameCommand request, CancellationToken cancellationToken)
        {
            var todoListId = new TodoListId(request.TodoListId);
            var todoId = new TodoId(request.TodoId);
            var todoName = new TodoName(request.TodoName);

            var aggregateRoot = await repository.Get(todoListId);

            if (aggregateRoot == null) throw new NotFoundException($"The todo list with id {request.TodoListId} doesn't exist.");

            var aggregate = aggregateRoot.ChangeTodoName(todoId, todoName);

            await repository.Update(aggregateRoot);

            return new ChangeTodoNameResponse { Aggregate = aggregate };
        }
    }
}
