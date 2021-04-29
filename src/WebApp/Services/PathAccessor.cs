using $ext_safeprojectname$.Common;
using Microsoft.AspNetCore.Hosting;

namespace $safeprojectname$.Services
{
    public class PathAccessor : IPathAccessor
    {
        private readonly IWebHostEnvironment environment;

        public PathAccessor(IWebHostEnvironment environment)
        {
            this.environment = environment;
        }

        public string GetRootPath()
        {
            return environment.WebRootPath ?? string.Empty;
        }

        public string GetFilePath()
        {
            return @"C:\\Temp";
        }
    }
}
