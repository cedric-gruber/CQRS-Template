using $safeprojectname$.Enums;
using $safeprojectname$.Enums.TodoLists;
using $safeprojectname$.Models.TodoLists.ViewModels;
using MediatR;
using System.Collections.Generic;

namespace $safeprojectname$.Queries.TodoLists
{
    public class AllTodosQuery : IRequest<IEnumerable<AllTodosViewModel>>
    {
        public AllTodosSortBy? SortBy { get; set; }

        public SortOrder? SortOrder { get; set; }
    }
}
