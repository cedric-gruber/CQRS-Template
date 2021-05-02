using $ext_safeprojectname$.Command.Application.Infrastructure.TodoLists;
using $safeprojectname$.TodoLists;
using Microsoft.Extensions.DependencyInjection;

namespace $safeprojectname$
{
    public static class ModuleDependencies
    {
        public static IServiceCollection AddCommandInfrastructureModuleDependencies(this IServiceCollection services)
        {
            services.AddSingleton<ITodoFileService, TodoFileService>();

            return services;
        }
    }
}
