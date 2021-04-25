using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace $safeprojectname$
{
    public static class MediatrDependencies
    {
        public static void AddMediatRDependencies(this IServiceCollection services)
        {
            services.AddMediatR(AppDomain.CurrentDomain.GetAssemblies());
        }
    }
}
