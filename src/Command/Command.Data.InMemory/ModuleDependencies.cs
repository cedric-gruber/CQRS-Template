using $ext_safeprojectname$.Command.Application.Repositories;
using $safeprojectname$.Repositories;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.DependencyInjection;

namespace $safeprojectname$
{
    public static class ModuleDependencies
    {
        public static IServiceCollection AddCommandDataInMemoryModuleDependencies(this IServiceCollection services)
        {
            services.AddSingleton<IMemoryCache, MemoryCache>();
            services.AddSingleton<ITodoListRepository, TodoListRepository>();

            return services;
        }
    }
}
