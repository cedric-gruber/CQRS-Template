using Microsoft.Extensions.DependencyInjection;
using $ext_safeprojectname$.Query.Application.Repositories;

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
