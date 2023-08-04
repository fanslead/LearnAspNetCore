namespace LearnHttpClient
{
    public interface IExampleService
    {
        Task<string> GetData();
    }

    public class ExampleService : IExampleService
    {
        private readonly HttpClient _httpClient;

        public ExampleService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<string> GetData()
        {
            HttpResponseMessage response = await _httpClient.GetAsync("");
            response.EnsureSuccessStatusCode();

            return await response.Content.ReadAsStringAsync();
        }
    }
}
