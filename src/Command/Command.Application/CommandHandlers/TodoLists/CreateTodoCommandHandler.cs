using $safeprojectname$.Commands.TodoLists;
using $safeprojectname$.Commands.TodoLists.Responses;
using $safeprojectname$.Infrastructure.TodoLists;
using $safeprojectname$.Repositories;
using $ext_safeprojectname$.Command.Domain.TodoLists.ValueObjects;
using $ext_safeprojectname$.Common.Exceptions;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace $safeprojectname$.CommandHandlers.TodoLists
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

            var todoList = await repository.Get(todoListId);

            if (todoList == null) throw new NotFoundException($"The todo list with id {request.TodoListId} doesn't exist.");

            var aggregate = todoList.AddTodo(todoName);

            fileService.AddOrUpdateFile(aggregate, request.Content);

            await repository.Update(todoList);

            return new CreateTodoResponse { Aggregate = aggregate };
        }
    }
}
