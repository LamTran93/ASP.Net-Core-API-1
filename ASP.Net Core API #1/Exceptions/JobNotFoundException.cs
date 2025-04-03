namespace ASP.Net_Core_API__1.Exceptions
{
    public class JobNotFoundException : Exception
    {
        public JobNotFoundException() : base("Job not found") { }
    }
}
