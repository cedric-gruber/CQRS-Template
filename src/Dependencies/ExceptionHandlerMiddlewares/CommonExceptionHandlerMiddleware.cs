using $ext_safeprojectname$.Common.Exceptions;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System.Net;
using System.Threading.Tasks;

namespace $safeprojectname$.ExceptionHandlerMiddlewares
{
    public class CommonExceptionHandlerMiddleware : AbstractExceptionHandlerMiddleware
    {
        public CommonExceptionHandlerMiddleware(
            RequestDelegate next,
            ILogger<CommonExceptionHandlerMiddleware> logger)
            : base(next, logger) { }

        public override async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await next(context);
            }
            catch (NotFoundException ex) { await HandleException(context, HttpStatusCode.NotFound, ex.Message); }
            catch (EmptyParameterException ex) { await HandleException(context, HttpStatusCode.BadRequest, ex.Message); }
            catch { throw; }
        }
    }
}
