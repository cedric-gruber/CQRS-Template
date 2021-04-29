using $safeprojectname$.Commands.TodoLists.Responses;
using MediatR;

namespace $safeprojectname$.Commands.TodoLists
{
    public class CreateTodoListCommand : IRequest<CreateTodoListResponse>
    {
        public string TodoListName { get; set; }
    }
}
