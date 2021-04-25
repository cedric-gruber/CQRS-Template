using Microsoft.Extensions.DependencyInjection;
using $ext_safeprojectname$.Command.Application.Infrastructure;

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
