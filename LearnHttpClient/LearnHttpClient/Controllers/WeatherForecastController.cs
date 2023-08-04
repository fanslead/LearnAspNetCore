using Microsoft.AspNetCore.Mvc;

namespace LearnHttpClient.Controllers
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
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IExampleService _exampleService;

        public WeatherForecastController(ILogger<WeatherForecastController> logger, 
            IHttpClientFactory httpClientFactory, 
            IExampleService exampleService)
        {
            _logger = logger;
            _httpClientFactory = httpClientFactory;
            _exampleService = exampleService;
        }

        [HttpGet(Name = "GetWeatherForecast")]
        public IEnumerable<WeatherForecast> Get()
        {
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToArray();
        }
        [HttpGet("Test")]
        public async Task Test()
        {
            using (HttpClient client = new HttpClient())
            {
                HttpResponseMessage response = await client.GetAsync("https://www.baidu.com");
                response.EnsureSuccessStatusCode();
                string responseBody = await response.Content.ReadAsStringAsync();
                Console.WriteLine(responseBody);
            }
        }
        [HttpGet("TestHttpClientFactory")]
        public async Task TestHttpClientFactory()
        {
            //var httpClient = _httpClientFactory.CreateClient();
            //HttpResponseMessage response = await httpClient.GetAsync("https://www.baidu.com");
            //response.EnsureSuccessStatusCode();

            //string responseBody = await response.Content.ReadAsStringAsync();
            //Console.WriteLine(responseBody);
            var httpClient = _httpClientFactory.CreateClient("ExampleClient");
            HttpResponseMessage response = await httpClient.GetAsync("");
            response.EnsureSuccessStatusCode();

            string responseBody = await response.Content.ReadAsStringAsync();
            Console.WriteLine(responseBody);
        }
        [HttpGet("TestExampleService")]
        public async Task TestExampleService()
        {
            var response = await _exampleService.GetData();
            Console.WriteLine(response);
        }
    }
}