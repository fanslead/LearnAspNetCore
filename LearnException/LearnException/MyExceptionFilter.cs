using Microsoft.AspNetCore.Mvc.Filters;
using static System.Net.Mime.MediaTypeNames;

namespace LearnException
{
    public class MyExceptionFilter : IAsyncExceptionFilter
    {
        public async Task OnExceptionAsync(ExceptionContext context)
        {
            context.HttpContext.Response.StatusCode = StatusCodes.Status500InternalServerError;

            // using static System.Net.Mime.MediaTypeNames;
            context.HttpContext.Response.ContentType = Text.Plain;

            await context.HttpContext.Response.WriteAsync("An exception was thrown. by MyExceptionFilter");
            context.ExceptionHandled = true;
        }
    }
}
