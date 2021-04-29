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

            var todoList = await repository.Get(todoListId);

            if (todoList == null) throw new NotFoundException($"The todo list with id {request.TodoListId} doesn't exist.");

            todoList.ChangeName(todoListName);

            await repository.Update(todoList);

            return new ChangeTodoListNameResponse { Aggregate = todoList };
        }
    }
}
