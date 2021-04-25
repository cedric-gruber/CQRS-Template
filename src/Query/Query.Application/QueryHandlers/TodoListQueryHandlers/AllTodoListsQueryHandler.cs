using AutoMapper;
using MediatR;
using $ext_safeprojectname$.Common.Exceptions;
using $safeprojectname$.Enums;
using $safeprojectname$.Enums.TodoList;
using $safeprojectname$.Models.TodoListModels.ViewModels;
using $safeprojectname$.Queries.TodoListQueries;
using $safeprojectname$.Repositories;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace $safeprojectname$.QueryHandlers.TodoListQueryHandlers
{
    public class AllTodoListsQueryHandler : IRequestHandler<AllTodoListsQuery, IEnumerable<AllTodoListsViewModel>>
    {
        private readonly IMapper mapper;
        private readonly ITodoListRepository repository;

        public AllTodoListsQueryHandler(IMapper mapper, ITodoListRepository repository)
        {
            this.mapper = mapper;
            this.repository = repository;
        }

        public async Task<IEnumerable<AllTodoListsViewModel>> Handle(AllTodoListsQuery request, CancellationToken cancellationToken)
        {
            if (request.SortBy != null && request.SortOrder == null)
                throw new EmptyParameterException("Sort order cannot be empty when sort by is specified");

            if (request.SortBy == null && request.SortOrder != null)
                throw new EmptyParameterException("Sort by cannot be empty when sort order is specified");

            var result = await repository.GetAllTodoLists();

            if (request.SortBy != null)
            {
                switch (request.SortBy)
                {
                    case AllTodoListsSortBy.Name:
                        result = request.SortOrder == SortOrder.Ascending ?
                            result.OrderBy(m => m.Name) : result.OrderByDescending(m => m.Name);
                        break;
                    case AllTodoListsSortBy.NumberOfTodos:
                        result = request.SortOrder == SortOrder.Ascending ?
                            result.OrderBy(m => m.NumberOfTodos) : result.OrderByDescending(m => m.NumberOfTodos);
                        break;
                }
            }

            return mapper.Map<IEnumerable<AllTodoListsViewModel>>(result);
        }
    }
}
