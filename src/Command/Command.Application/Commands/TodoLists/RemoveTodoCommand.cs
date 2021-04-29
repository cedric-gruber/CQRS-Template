using $safeprojectname$.Commands.TodoLists.Responses;
using MediatR;
using System;

namespace $safeprojectname$.Commands.TodoLists
{
    public class RemoveTodoCommand : IRequest<RemoveTodoResponse>
    {
        public Guid TodoListId { get; set; }
        public Guid TodoId { get; set; }
    }
}
