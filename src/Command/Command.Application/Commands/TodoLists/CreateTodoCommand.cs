using $safeprojectname$.Commands.TodoLists.Responses;
using MediatR;
using System;

namespace $safeprojectname$.Commands.TodoLists
{
    public class CreateTodoCommand : IRequest<CreateTodoResponse>
    {
        public Guid TodoListId { get; set; }
        public string TodoName { get; set; }
        public string Content { get; set; }
    }
}
