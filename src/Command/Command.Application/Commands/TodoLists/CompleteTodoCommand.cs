using $safeprojectname$.Commands.TodoLists.Responses;
using MediatR;
using System;

namespace $safeprojectname$.Commands.TodoLists
{
    public class CompleteTodoCommand : IRequest<CompleteTodoResponse>
    {
        public Guid TodoListId { get; set; }
        public Guid TodoId { get; set; }
    }
}
