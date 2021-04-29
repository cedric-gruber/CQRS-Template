using $ext_safeprojectname$.Command.Application;
using $ext_safeprojectname$.Query.Application;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Reflection;

namespace $safeprojectname$
{
    public static class MediatrDependencies
    {
        public static void AddMediatR(this IServiceCollection services)
        {
            var assemblies = new Assembly[]
                {
                    Command.Application.AssemblyAccessor.GetAssembly(),
                    Query.Application.AssemblyAccessor.GetAssembly()
                };

            services.AddMediatR(assemblies);
        }
    }
}
