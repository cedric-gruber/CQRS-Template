using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System.Net;
using System.Text.Json;
using System.Threading.Tasks;

namespace $safeprojectname$.ExceptionMiddlewares
{
    public abstract class AbstractExceptionHandlerMiddleware
    {
        protected readonly RequestDelegate next;
        protected readonly ILogger logger;

        public AbstractExceptionHandlerMiddleware(RequestDelegate next, ILogger logger)
        {
            this.next = next;
            this.logger = logger;
        }

        public abstract Task InvokeAsync(HttpContext context);

        protected Task HandleException(HttpContext context, HttpStatusCode statusCode, string message)
        {
            context.Response.StatusCode = (int)statusCode;
            context.Response.ContentType = "application/json";
            return context.Response.WriteAsync(ErrorDetails.Write((int)statusCode, message));
        }
    }

    internal class ErrorDetails
    {
        public int StatusCode { get; }
        public string Message { get; }

        private ErrorDetails(int statusCode, string message)
        {
            StatusCode = statusCode;
            Message = message;
        }

        public override string ToString()
        {
            return JsonSerializer.Serialize(this);
        }

        public static string Write(int statusCode, string message)
        {
            var obj = new ErrorDetails(statusCode, message);
            return obj.ToString();
        }
    }
}
