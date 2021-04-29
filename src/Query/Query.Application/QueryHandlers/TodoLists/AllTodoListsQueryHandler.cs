using AutoMapper;
using $ext_safeprojectname$.Common.Exceptions;
using $safeprojectname$.Extensions.TodoLists;
using $safeprojectname$.Models.TodoLists.ViewModels;
using $safeprojectname$.Queries.TodoLists;
using $safeprojectname$.Repositories;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace $safeprojectname$.QueryHandlers.TodoLists
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

            var projections = await repository.GetAllTodoLists();

            if(request.SortBy != null)
                projections = projections.SortBy(request.SortBy.Value, request.SortOrder.Value);

            return mapper.Map<IEnumerable<AllTodoListsViewModel>>(projections);
        }


    }
}
