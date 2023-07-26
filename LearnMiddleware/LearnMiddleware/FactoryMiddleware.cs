using Microsoft.Extensions.Logging;

namespace LearnMiddleware
{
    public class FactoryMiddleware : IMiddleware
    {
        private readonly ILogger _logger;
        private readonly TestMiddlewareDi _testMiddleware;

        public FactoryMiddleware(ILogger<FactoryMiddleware> logger, TestMiddlewareDi testMiddleware)
        {
            _logger = logger;
            _testMiddleware = testMiddleware;
        }

        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            _logger.LogInformation("FactoryMiddleware Invoke");
            _logger.LogInformation($"FactoryMiddleware _testMiddlewareDi: {_testMiddleware.Id}");
            await next(context);
        }
    }
}
