namespace Domain.Exceptions
{
    public class NotFoundException : Exception
    {
        public NotFoundException() : base("Job not found") { }
        public NotFoundException(string message) : base(message) { }
    }
}
