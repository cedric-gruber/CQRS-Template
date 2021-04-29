using $safeprojectname$.Commands.TodoLists.Responses;
using MediatR;
using System;

namespace $safeprojectname$.Commands.TodoLists
{
    public class ChangeTodoNameCommand : IRequest<ChangeTodoNameResponse>
    {
        public Guid TodoListId { get; set; }
        public Guid TodoId { get; set; }
        public string TodoName { get; set; }
    }
}
