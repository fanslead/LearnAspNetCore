using Microsoft.AspNetCore.Mvc;

namespace LearnDI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {

        private static readonly string[] Summaries = new[]
        {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

        private readonly ILogger<WeatherForecastController> _logger;
        private readonly TestScoped _testScoped;
        private readonly TestSingleton _testSingleton;
        private readonly TestTransient _testTransient;
        private readonly IScopedDependency _scopedDependency;

        public WeatherForecastController(ILogger<WeatherForecastController> logger, 
            TestScoped testScoped, TestSingleton testSingleton, TestTransient testTransient, 
            IScopedDependency scopedDependency,
            IEnumerable<IScopedDependency> scopedDependencies)
        {
            _logger = logger;
            _testScoped = testScoped;
            _testSingleton = testSingleton;
            _testTransient = testTransient;
            _scopedDependency = scopedDependency;
        }

        [HttpGet(Name = "GetWeatherForecast")]
        public IEnumerable<WeatherForecast> Get()
        {
            Console.WriteLine($"TestSingleton --- {_testSingleton.Id}");
            Console.WriteLine($"TestScoped --- {_testScoped.Id}");
            Console.WriteLine($"TestTransient --- {_testTransient.Id}");
            Console.WriteLine("-----------");
            _testSingleton.Console();
            Console.WriteLine("-----------");
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToArray();
        }
    }
}