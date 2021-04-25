using Microsoft.Extensions.DependencyInjection;
using $ext_safeprojectname$.Query.Application.Infrastructure;

namespace $safeprojectname$
{
    public static class ModuleDependencies
    {
        public static void AddQueryInfrastructureModuleDependencies(this IServiceCollection services)
        {
            services.AddSingleton<ITodoFileService, TodoFileService>();
        }
    }
}
