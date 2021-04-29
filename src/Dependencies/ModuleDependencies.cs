using $ext_safeprojectname$.Command.Application;
using $ext_safeprojectname$.Command.Data.InMemory;
using $ext_safeprojectname$.Command.Domain;
using $ext_safeprojectname$.Command.Infrastructure;
using $ext_safeprojectname$.Common;
using $ext_safeprojectname$.Common.Infrastructure.FileSystem;
using $ext_safeprojectname$.Query.Application;
using $ext_safeprojectname$.Query.Data.InMemory;
using $ext_safeprojectname$.Query.Infrastructure;
using Microsoft.Extensions.DependencyInjection;

namespace $safeprojectname$
{
    public static class ModuleDependencies
    {
        public static void AddModuleDependencies(this IServiceCollection services)
        {
            services.AddCommonModuleDependencies();
            services.AddCommonInfrastructureFileSystemModuleDependencies();

            services.AddCommandDomainModuleDependencies();
            services.AddCommandApplicationModuleDependencies();
            services.AddCommandDataInMemoryModuleDependencies();
            services.AddCommandInfrastructureModuleDependencies();

            services.AddQueryApplicationModuleDependencies();
            services.AddQueryDataInMemoryModuleDependencies();
            services.AddQueryInfrastructureModuleDependencies();
        }
    }
}
