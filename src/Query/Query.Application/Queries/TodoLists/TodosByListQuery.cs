using $safeprojectname$.Models.TodoLists.ViewModels;
using MediatR;
using System;
using System.Collections.Generic;

namespace $safeprojectname$.Queries.TodoLists
{
    public class TodosByListQuery : IRequest<IEnumerable<TodosByListViewModel>>
    {
        public Guid TodoListId { get; set; }
    }
}
