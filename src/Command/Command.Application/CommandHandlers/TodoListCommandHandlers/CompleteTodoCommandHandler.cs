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
    public class CompleteTodoCommandHandler : IRequestHandler<CompleteTodoCommand, CompleteTodoResponse>
    {
        private readonly ITodoListRepository repository;

        public CompleteTodoCommandHandler(ITodoListRepository repository)
        {
            this.repository = repository;
        }

        public async Task<CompleteTodoResponse> Handle(CompleteTodoCommand request, CancellationToken cancellationToken)
        {
            var todoListId = new TodoListId(request.TodoListId);
            var todoId = new TodoId(request.TodoId);

            var aggregateRoot = await repository.Get(todoListId);

            if (aggregateRoot == null) throw new NotFoundException($"The todo list with id {request.TodoListId} doesn't exist.");

            var aggregate = aggregateRoot.CompleteTodo(todoId);

            await repository.Update(aggregateRoot);

            return new CompleteTodoResponse { Aggregate = aggregate };
        }
    }
}
