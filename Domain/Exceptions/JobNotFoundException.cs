namespace Domain.Exceptions
{
    public class JobNotFoundException : Exception
    {
        public JobNotFoundException() : base("Job not found") { }
        public JobNotFoundException(string message) : base(message) { }
    }
}
