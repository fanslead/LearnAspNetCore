namespace LearnMiddleware
{
    public class AMiddleware
    {
        private readonly RequestDelegate _next;

        public AMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context, ILogger<AMiddleware> logger, TestMiddlewareDi testMiddleware)
        {
            logger.LogInformation("AMiddleware Invoke");
            logger.LogInformation($"AMiddleware _testMiddlewareDi: {testMiddleware.Id}");

            await _next(context);
        }
    }
}
