using Microsoft.AspNetCore.Diagnostics;
using static System.Net.Mime.MediaTypeNames;

namespace LearnException
{
    public class MyExceptionMiddleware
    {
        private readonly RequestDelegate _next;

        public MyExceptionMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                context.Response.StatusCode = StatusCodes.Status500InternalServerError;

                // using static System.Net.Mime.MediaTypeNames;
                context.Response.ContentType = Text.Plain;

                await context.Response.WriteAsync("An exception was thrown.");


                if (ex is FileNotFoundException)
                {
                    await context.Response.WriteAsync(" The file was not found.");
                }
            }
        }
    }
}
