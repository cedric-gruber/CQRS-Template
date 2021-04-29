using $ext_safeprojectname$.Query.Application.Infrastructure.TodoLists;
using $safeprojectname$.TodoLists;
using Microsoft.Extensions.DependencyInjection;

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
