using MediatR;
using $safeprojectname$.Commands.TodoListResponses;
using System;

namespace $safeprojectname$.Commands.TodoListCommands
{
    public class CompleteTodoCommand : IRequest<CompleteTodoResponse>
    {
        public Guid TodoListId { get; set; }
        public Guid TodoId { get; set; }
    }
}
