using $safeprojectname$.Enums;
using $safeprojectname$.Enums.TodoLists;
using $safeprojectname$.Models.TodoLists.Projections;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace $safeprojectname$.Extensions.TodoLists
{
    internal static class SortByExtensions
    {
        internal static IOrderedEnumerable<AllTodoListsProjection> SortBy(this IEnumerable<AllTodoListsProjection> source, AllTodoListsSortBy sortBy, SortOrder sortOrder)
        {
            switch (sortBy)
            {
                case AllTodoListsSortBy.Name: return source.Sort(m => m.Name, sortOrder);
                case AllTodoListsSortBy.NumberOfTodos: return source.Sort(m => m.NumberOfTodos, sortOrder);
                default: throw new NotImplementedException($"The sortBy enum value {sortBy} is not implemented");
            }
        }

        internal static IOrderedEnumerable<AllTodosProjection> SortBy(this IEnumerable<AllTodosProjection> source, AllTodosSortBy sortBy, SortOrder sortOrder)
        {
            switch (sortBy)
            {
                case AllTodosSortBy.Name: return source.Sort(m => m.Name, sortOrder);
                case AllTodosSortBy.ListName: return source.Sort(m => m.ListName, sortOrder);
                default: throw new NotImplementedException($"The sortBy enum value {sortBy} is not implemented");
            }
        }
    }
}
