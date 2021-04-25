using Microsoft.Extensions.DependencyInjection;

namespace $safeprojectname$
{
    public static class ModuleDependencies
    {
        public static void AddCommonInfrastructureFileSystemModuleDependencies(this IServiceCollection services)
        {
            services.AddSingleton<IFileService, FileService>();
        }
    }
}
