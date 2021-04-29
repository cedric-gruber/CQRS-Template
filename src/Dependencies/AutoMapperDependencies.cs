using AutoMapper;
using $ext_safeprojectname$.Query.Application.Models;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace $safeprojectname$
{
    public static class AutoMapperDependencies
    {
        public static void AddAutoMapper(this IServiceCollection services, Action<IMapperConfigurationExpression> addCallerProfiles = null)
        {
            var mapperConfig = new MapperConfiguration(configure =>
            {
                configure.AddQueryApplicationProfiles();
                if (addCallerProfiles != null) addCallerProfiles(configure);
            });

            IMapper mapper = mapperConfig.CreateMapper();
            services.AddSingleton(mapper);
        }
    }
}
