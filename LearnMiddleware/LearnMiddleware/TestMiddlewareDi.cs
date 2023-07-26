namespace LearnMiddleware
{
    public class TestMiddlewareDi
    {
        public TestMiddlewareDi()
        {
            Id = Guid.NewGuid();
        }

        public Guid Id { get; set; }
    }
}
