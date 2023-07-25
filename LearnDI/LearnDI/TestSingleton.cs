namespace LearnDI
{
    public class TestSingleton
    {
        private readonly IServiceScopeFactory _serviceScopeFactory;
        public TestSingleton(IServiceScopeFactory serviceScopeFactory)
        {
            _serviceScopeFactory = serviceScopeFactory;
            Id = Guid.NewGuid();
        }

        public Guid Id { get; set; }

        public void Console()
        {
            using(var scope = _serviceScopeFactory.CreateScope()) 
            {
                var testScoped = scope.ServiceProvider.GetRequiredService<TestScoped>();
                System.Console.WriteLine($"TestSingleton - TestScoped: {testScoped.Id}");
            }
        }
    }
}
