using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using $ext_safeprojectname$.Query.Application.Models.Mappings;

namespace $safeprojectname$
{
    public static class AutoMapperDependencies
    {
        public static void AddAutoMapperDependencies(this IServiceCollection services)
        {
            var mapperConfig = new MapperConfiguration(mc =>
            {
                mc.AddQueryApplicationProfiles();
            });

            IMapper mapper = mapperConfig.CreateMapper();
            services.AddSingleton(mapper);
        }
    }
}
