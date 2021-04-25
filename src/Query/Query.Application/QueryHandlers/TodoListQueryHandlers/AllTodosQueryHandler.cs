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
    public class AllTodosQueryHandler : IRequestHandler<AllTodosQuery, IEnumerable<AllTodosViewModel>>
    {
        private readonly IMapper mapper;
        private readonly ITodoListRepository repository;

        public AllTodosQueryHandler(IMapper mapper, ITodoListRepository repository)
        {
            this.mapper = mapper;
            this.repository = repository;
        }

        public async Task<IEnumerable<AllTodosViewModel>> Handle(AllTodosQuery request, CancellationToken cancellationToken)
        {
            if (request.SortBy != null && request.SortOrder == null)
                throw new EmptyParameterException("Sort order cannot be empty when sort by is specified");

            if (request.SortBy == null && request.SortOrder != null)
                throw new EmptyParameterException("Sort by cannot be empty when sort order is specified");

            var result = await repository.GetAllTodos();

            if (request.SortBy != null)
            {
                switch (request.SortBy)
                {
                    case AllTodosSortBy.Name:
                        result = request.SortOrder == SortOrder.Ascending ?
                            result.OrderBy(m => m.Name) : result.OrderByDescending(m => m.Name);
                        break;
                    case AllTodosSortBy.ListName:
                        result = request.SortOrder == SortOrder.Ascending ?
                            result.OrderBy(m => m.ListName) : result.OrderByDescending(m => m.ListName);
                        break;
                }
            }

            return mapper.Map<IEnumerable<AllTodosViewModel>>(result);
        }
    }
}
