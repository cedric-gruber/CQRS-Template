using $safeprojectname$.Commands.TodoLists;
using $safeprojectname$.Commands.TodoLists.Responses;
using $safeprojectname$.Repositories;
using $ext_safeprojectname$.Command.Domain.TodoLists.ValueObjects;
using $ext_safeprojectname$.Common.Exceptions;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace $safeprojectname$.CommandHandlers.TodoLists
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

            var todoList = await repository.Get(todoListId);

            if (todoList == null) throw new NotFoundException($"The todo list with id {request.TodoListId} doesn't exist.");

            var todo = todoList.ChangeTodoName(todoId, todoName);

            await repository.Save(todoList);

            return new ChangeTodoNameResponse { Aggregate = todo };
        }
    }
}
