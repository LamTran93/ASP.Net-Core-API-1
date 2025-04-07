namespace Domain.Exceptions
{
    public class ExistedException : Exception
    {
        public ExistedException() : base("Job already existed") { }
        public ExistedException(string message) : base(message) { }
    }
}
