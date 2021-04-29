using $ext_safeprojectname$.Command.Application.Infrastructure.TodoLists;
using $safeprojectname$.TodoLists;
using Microsoft.Extensions.DependencyInjection;

namespace $safeprojectname$
{
    public static class ModuleDependencies
    {
        public static void AddCommandInfrastructureModuleDependencies(this IServiceCollection services)
        {
            services.AddSingleton<ITodoFileService, TodoFileService>();
        }
    }
}
