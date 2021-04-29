using AutoMapper;
using $safeprojectname$.Models.TodoLists.Projections;
using $safeprojectname$.Models.TodoLists.ViewModels;

namespace $safeprojectname$.Models.TodoLists.Mappings.Profiles
{
    public class AllTodosProfile : Profile
    {
        public AllTodosProfile()
        {
            CreateMap<AllTodosProjection, AllTodosViewModel>()
                .ForMember(dest => dest.Id, config => config.MapFrom(src => src.Id))
                .ForMember(dest => dest.Name, config => config.MapFrom(src => src.Name))
                .ForMember(dest => dest.ListName, config => config.MapFrom(src => src.ListName));
        }
    }
}
