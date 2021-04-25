using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using $safeprojectname$.ExceptionMiddlewares;

namespace $safeprojectname$
{
    public static class ExceptionDependencies
    {
        public static void AddExceptionMiddlewares(this IApplicationBuilder app)
        {
            app.UseMiddleware<ExceptionHandlerMiddleware>();
            app.UseMiddleware<CommonExceptionHandlerMiddleware>();
            app.UseMiddleware<CommandExceptionHandlerMiddleware>();
            app.UseMiddleware<QueryExceptionHandlerMiddleware>();
        }
    }
}
