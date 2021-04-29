using $safeprojectname$.ExceptionHandlerMiddlewares;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;

namespace $safeprojectname$
{
    public static class ExceptionDependencies
    {
        public static void AddExceptionHandlerMiddlewares(this IApplicationBuilder app)
        {
            app.UseMiddleware<ExceptionHandlerMiddleware>();
            app.UseMiddleware<CommonExceptionHandlerMiddleware>();
            app.UseMiddleware<CommandExceptionHandlerMiddleware>();
            app.UseMiddleware<QueryExceptionHandlerMiddleware>();
        }
    }
}
