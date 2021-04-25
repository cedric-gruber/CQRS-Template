using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using $ext_safeprojectname$.Command.Domain.TodoList.Exceptions;
using System.Net;
using System.Threading.Tasks;

namespace $safeprojectname$.ExceptionMiddlewares
{
    public class CommandExceptionHandlerMiddleware : AbstractExceptionHandlerMiddleware
    {
        public CommandExceptionHandlerMiddleware(
            RequestDelegate next,
            ILogger<CommandExceptionHandlerMiddleware> logger) 
            : base(next, logger) { }

        public override async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await next(context);
            }
            catch (NameInvalidException ex) { await HandleException(context, HttpStatusCode.Forbidden, ex.Message); }
            catch (TodoAlreadyCompletedException ex) { await HandleException(context, HttpStatusCode.Forbidden, ex.Message); }
            catch { throw; }
        }
    }
}
