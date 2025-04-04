namespace Domain.Exceptions
{
    public class DuplicatedJobException : Exception
    {
        public DuplicatedJobException() : base("Job already exists") { }
        public DuplicatedJobException(string message) : base(message) { }
    }
}
