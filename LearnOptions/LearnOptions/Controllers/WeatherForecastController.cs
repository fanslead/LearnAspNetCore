using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace LearnOptions.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

        private readonly MyOptions _options;
        private readonly MyOptions _options2;
        private MyOptions _options3;
        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger, IOptions<MyOptions> options, IOptionsSnapshot<MyOptions> options2, IOptionsMonitor<MyOptions> options3)
        {
            _logger = logger;
            _options = options.Value;
            _options2 = options2.Value;
            _options3 = options3.CurrentValue;
            options3.OnChange(o => _options3 = options3.CurrentValue);

            var nameOption = options2.Get("Abcd");
            var nameOption2 = options3.Get("OptionsBuilderOptions");
            var nameOption3 = options3.Get("ValidateOptions");
        }
        
        [HttpGet(Name = "GetWeatherForecast")]
        public IEnumerable<WeatherForecast> Get()
        {
            // Ê¹ÓÃÅäÖÃÖµ
            var option1Value = _options.Option1;
            var option2Value = _options.Option2;
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