﻿using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.DependencyInjection;
using $ext_safeprojectname$.Command.Application.Repositories;

namespace $safeprojectname$
{
    public static class ModuleDependencies
    {
        public static void AddCommandDataInMemoryModuleDependencies(this IServiceCollection services)
        {
            services.AddSingleton<IMemoryCache, MemoryCache>();
            services.AddSingleton<ITodoListRepository, TodoListRepository>();
        }
    }
}