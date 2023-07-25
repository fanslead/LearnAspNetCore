using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;

namespace StartupHostLib
{
    public class StartupFilterOne : IStartupFilter
    {
        public Action<IApplicationBuilder> Configure(Action<IApplicationBuilder> next)
        {
            return builder => 
            {
                builder.Use(async (httpContext, _next) => 
                {
                    Console.WriteLine("-----StartupFilterOne-----");
                    await _next();
                });
                next(builder);
            };
        }
    }
}
