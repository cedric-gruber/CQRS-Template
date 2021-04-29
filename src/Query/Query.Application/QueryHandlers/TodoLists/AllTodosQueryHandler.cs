using AutoMapper;
using $ext_safeprojectname$.Common.Exceptions;
using $safeprojectname$.Enums;
using $safeprojectname$.Enums.TodoLists;
using $safeprojectname$.Extensions;
using $safeprojectname$.Extensions.TodoLists;
using $safeprojectname$.Models.TodoLists.ViewModels;
using $safeprojectname$.Queries.TodoLists;
using $safeprojectname$.Repositories;
using MediatR;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace $safeprojectname$.QueryHandlers.TodoLists
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

            var projections = await repository.GetAllTodos();

            if (request.SortBy != null)
                projections.SortBy(request.SortBy.Value, request.SortOrder.Value);

            return mapper.Map<IEnumerable<AllTodosViewModel>>(projections);
        }
    }
}
