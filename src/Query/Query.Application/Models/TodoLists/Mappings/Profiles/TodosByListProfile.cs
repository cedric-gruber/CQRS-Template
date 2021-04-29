using AutoMapper;
using $safeprojectname$.Models.TodoLists.Projections;
using $safeprojectname$.Models.TodoLists.ViewModels;

namespace $safeprojectname$.Models.TodoLists.Mappings.Profiles
{
    public class TodosByListProfile : Profile
    {
        public TodosByListProfile()
        {
            CreateMap<TodosByListProjection, TodosByListViewModel>()
                    .ForMember(dest => dest.Id, config => config.MapFrom(src => src.Id))
                    .ForMember(dest => dest.Name, config => config.MapFrom(src => src.Name))
                    .ForMember(dest => dest.IsCompleted, config => config.MapFrom(src => src.IsCompleted));
        }
    }
}
