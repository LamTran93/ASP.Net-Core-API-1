namespace Domain.Exceptions
{
    public class InvalidException : Exception
    {
        public InvalidException() : base("Invalid job") { }
        public InvalidException(string message) : base(message) { }
    }
}
