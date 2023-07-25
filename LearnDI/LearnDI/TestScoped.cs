namespace LearnDI
{
    public class TestScoped
    {
        public TestScoped()
        {
            Id = Guid.NewGuid();
        }

        public Guid Id { get; set; }
    }
}
