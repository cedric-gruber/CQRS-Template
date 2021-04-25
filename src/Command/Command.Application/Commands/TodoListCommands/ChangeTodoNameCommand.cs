using MediatR;
using $safeprojectname$.Commands.TodoListResponses;
using System;

namespace $safeprojectname$.Commands.TodoListCommands
{
    public class ChangeTodoNameCommand : IRequest<ChangeTodoNameResponse>
    {
        public Guid TodoListId { get; set; }
        public Guid TodoId { get; set; }
        public string TodoName { get; set; }
    }
}
