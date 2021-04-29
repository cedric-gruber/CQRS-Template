using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace $safeprojectname$.ExceptionHandlerMiddlewares
{
    public class QueryExceptionHandlerMiddleware : AbstractExceptionHandlerMiddleware
    {
        public QueryExceptionHandlerMiddleware(
            RequestDelegate next,
            ILogger<QueryExceptionHandlerMiddleware> logger)
            : base(next, logger) { }

        public override async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await next(context);
            }
            catch { throw; }
        }
    }
}
