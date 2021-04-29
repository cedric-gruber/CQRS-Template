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

            var todoList = await repository.Get(todoListId);

            if (todoList == null) throw new NotFoundException($"The todo list with id {request.TodoListId} doesn't exist.");

            var todo = todoList.CompleteTodo(todoId);

            await repository.Update(todoList);

            return new CompleteTodoResponse { Aggregate = todo };
        }
    }
}
