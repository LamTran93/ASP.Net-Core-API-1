namespace Domain.Exceptions
{
    public class InvalidJobException : Exception
    {
        public InvalidJobException() : base("Invalid job") { }
        public InvalidJobException(string message) : base(message) { }
    }
}
