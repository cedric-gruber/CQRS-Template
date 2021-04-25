using MediatR;
using $safeprojectname$.Commands.TodoListResponses;
using System;

namespace $safeprojectname$.Commands.TodoListCommands
{
    public class CreateTodoCommand : IRequest<CreateTodoResponse>
    {
        public Guid TodoListId { get; set; }
        public string TodoName { get; set; }
        public string Content { get; set; }
    }
}
