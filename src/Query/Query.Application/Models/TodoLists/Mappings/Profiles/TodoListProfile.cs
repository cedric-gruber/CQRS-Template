using AutoMapper;
using $safeprojectname$.Models.TodoLists.Projections;
using $safeprojectname$.Models.TodoLists.ViewModels;

namespace $safeprojectname$.Models.TodoLists.Mappings.Profiles
{
    public class TodoListProfile : Profile
    {
        public TodoListProfile()
        {
            CreateMap<AllTodoListsProjection, AllTodoListsViewModel>()
                .ForMember(dest => dest.Id, config => config.MapFrom(src => src.Id))
                .ForMember(dest => dest.Name, config => config.MapFrom(src => src.Name))
                .ForMember(dest => dest.NumberOfTodos, config => config.MapFrom(src => src.NumberOfTodos));
        }
    }
}
