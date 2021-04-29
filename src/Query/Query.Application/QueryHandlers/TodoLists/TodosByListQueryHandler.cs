using AutoMapper;
using $safeprojectname$.Infrastructure.TodoLists;
using $safeprojectname$.Models.TodoLists.ViewModels;
using $safeprojectname$.Queries.TodoLists;
using $safeprojectname$.Repositories;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace $safeprojectname$.QueryHandlers.TodoLists
{
    public class TodosByListQueryHandler : IRequestHandler<TodosByListQuery, IEnumerable<TodosByListViewModel>>
    {
        private readonly IMapper mapper;
        private readonly ITodoListRepository repository;
        private readonly ITodoFileService fileService;

        public TodosByListQueryHandler(IMapper mapper, ITodoListRepository repository, ITodoFileService fileService)
        {
            this.mapper = mapper;
            this.repository = repository;
            this.fileService = fileService;
        }

        public async Task<IEnumerable<TodosByListViewModel>> Handle(TodosByListQuery request, CancellationToken cancellationToken)
        {
            var projections = await repository.GetTodosByList(request.TodoListId);

            var viewModels = mapper.Map<IEnumerable<TodosByListViewModel>>(projections);

            foreach (var viewModel in viewModels)
                viewModel.Content = fileService.GetFileContent(viewModel);

            return viewModels;
        }
    }
}
