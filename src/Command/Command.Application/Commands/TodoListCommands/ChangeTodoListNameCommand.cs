using MediatR;
using $safeprojectname$.Commands.TodoListResponses;
using System;

namespace $safeprojectname$.Commands.TodoListCommands
{
    public class ChangeTodoListNameCommand : IRequest<ChangeTodoListNameResponse>
    {
        public Guid TodoListId { get; set; }
        public string TodoListName { get; set; }
    }
}
