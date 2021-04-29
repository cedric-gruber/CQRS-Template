using $safeprojectname$.Commands.TodoLists.Responses;
using MediatR;
using System;

namespace $safeprojectname$.Commands.TodoLists
{
    public class ChangeTodoListNameCommand : IRequest<ChangeTodoListNameResponse>
    {
        public Guid TodoListId { get; set; }
        public string TodoListName { get; set; }
    }
}
