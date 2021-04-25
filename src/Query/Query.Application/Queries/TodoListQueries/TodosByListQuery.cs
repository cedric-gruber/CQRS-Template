using MediatR;
using $safeprojectname$.Models.TodoListModels.ViewModels;
using System;
using System.Collections.Generic;

namespace $safeprojectname$.Queries.TodoListQueries
{
    public class TodosByListQuery : IRequest<IEnumerable<TodosByListViewModel>>
    {
        public Guid TodoListId { get; set; }
    }
}
