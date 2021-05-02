using Microsoft.Extensions.DependencyInjection;

namespace $safeprojectname$
{
    public static class ModuleDependencies
    {
        public static IServiceCollection AddCommonInfrastructureFileSystemModuleDependencies(this IServiceCollection services)
        {
            services.AddSingleton<IFileService, FileService>();

            return services;
        }
    }
}
