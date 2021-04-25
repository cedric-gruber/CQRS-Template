using MediatR;
using $safeprojectname$.Enums;
using $safeprojectname$.Enums.TodoList;
using $safeprojectname$.Models.TodoListModels.ViewModels;
using System.Collections.Generic;

namespace $safeprojectname$.Queries.TodoListQueries
{
    public class AllTodoListsQuery : IRequest<IEnumerable<AllTodoListsViewModel>>
    {
        public AllTodoListsSortBy? SortBy { get; set; }

        public SortOrder? SortOrder { get; set; }
    }
}
