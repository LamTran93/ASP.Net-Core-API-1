namespace Domain.Exceptions
{
    public class DuplicatedException : Exception
    {
        public DuplicatedException() : base("Job already exists") { }
        public DuplicatedException(string message) : base(message) { }
    }
}
