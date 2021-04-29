using $ext_safeprojectname$.Query.Application.Repositories;
using $safeprojectname$.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace $safeprojectname$
{
    public static class ModuleDependencies
    {
        public static void AddQueryDataInMemoryModuleDependencies(this IServiceCollection services)
        {
            services.AddSingleton<ITodoListRepository, TodoListRepository>();
        }
    }
}
