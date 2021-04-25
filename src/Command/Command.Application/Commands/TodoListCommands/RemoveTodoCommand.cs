using MediatR;
using $safeprojectname$.Commands.TodoListResponses;
using System;

namespace $safeprojectname$.Commands.TodoListCommands
{
    public class RemoveTodoCommand : IRequest<RemoveTodoResponse>
    {
        public Guid TodoListId { get; set; }
        public Guid TodoId { get; set; }
    }
}
