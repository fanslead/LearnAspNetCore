using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;

[assembly: HostingStartup(typeof(StartupHostLib.OneHostingStartup))]
namespace StartupHostLib
{

    public class OneHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureAppConfiguration((config) => 
            {
                Console.WriteLine("ConfigureAppConfiguration");
            });
            builder.ConfigureServices(services =>
            {
                services.AddTransient<IStartupFilter, StartupFilterTwo>();
                services.AddTransient<IStartupFilter, StartupFilterOne>();
                Console.WriteLine("ConfigureServices");
            });
            builder.Configure(app =>
            {
                Console.WriteLine("Configure");
            });
        }
    }
}
