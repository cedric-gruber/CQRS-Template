using $safeprojectname$.Commands.TodoLists;
using $safeprojectname$.Commands.TodoLists.Responses;
using $safeprojectname$.Repositories;
using $ext_safeprojectname$.Command.Domain.TodoLists;
using $ext_safeprojectname$.Command.Domain.TodoLists.ValueObjects;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace $safeprojectname$.CommandHandlers.TodoLists
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

            var todoList = TodoList.Create(todoListName);

            await repository.Save(todoList);

            return new CreateTodoListResponse { Aggregate = todoList };
        }
    }
}
