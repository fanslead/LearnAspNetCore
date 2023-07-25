namespace LearnDI
{
    public class TestTransient : IDisposable
    {
        public TestTransient()
        {
            Id = Guid.NewGuid();
        }

        public Guid Id { get; set; }

        public void Dispose()
        {

        }
    }
}
