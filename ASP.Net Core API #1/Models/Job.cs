namespace ASP.Net_Core_API__1.Models
{
    public class Job
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public bool IsCompleted { get; set; }

        public void CopyFrom(Job other)
        {
            Id = other.Id;
            Title = other.Title;
            IsCompleted = other.IsCompleted;
        }
    }
}
