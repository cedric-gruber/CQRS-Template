using AutoMapper;
using MediatR;
using $safeprojectname$.Infrastructure;
using $safeprojectname$.Models.TodoListModels.ViewModels;
using $safeprojectname$.Queries.TodoListQueries;
using $safeprojectname$.Repositories;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace $safeprojectname$.QueryHandlers.TodoListQueryHandlers
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
            var result = await repository.GetTodosByList(request.TodoListId);

            var viewModels = mapper.Map<IEnumerable<TodosByListViewModel>>(result);

            foreach (var viewModel in viewModels)
                viewModel.Content = fileService.GetFileContent(viewModel);

            return viewModels;
        }
    }
}
