namespace Domain.Exceptions
{
    public class JobExistedException : Exception
    {
        public JobExistedException() : base("Job already existed") { }
        public JobExistedException(string message) : base(message) { }
    }
}
