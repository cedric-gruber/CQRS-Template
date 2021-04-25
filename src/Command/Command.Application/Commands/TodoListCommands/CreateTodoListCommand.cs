using MediatR;
using $safeprojectname$.Commands.TodoListResponses;

namespace $safeprojectname$.Commands.TodoListCommands
{
    public class CreateTodoListCommand : IRequest<CreateTodoListResponse>
    {
        public string TodoListName { get; set; }
    }
}
