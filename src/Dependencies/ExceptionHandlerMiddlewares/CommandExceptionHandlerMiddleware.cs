using $ext_safeprojectname$.Command.Domain.TodoLists.Exceptions;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System.Net;
using System.Threading.Tasks;

namespace $safeprojectname$.ExceptionHandlerMiddlewares
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
            catch (TodoListAlreadyCompletedException ex) { await HandleException(context, HttpStatusCode.Forbidden, ex.Message); }
            catch { throw; }
        }
    }
}
