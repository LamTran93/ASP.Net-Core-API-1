using Domain.Models;

namespace ASP.Net_Core_API__1.DTO
{
    public class JobDTO
    {
        public string Id { get; set; }
        public string Title { get; set; }
        public bool IsCompleted { get; set; }

        public JobDTO() { }

        public JobDTO(Job job)
        {
            Id = job.Id.ToString();
            Title = job.Title;
            IsCompleted = job.IsCompleted;
        }

        public Job ToJob()
        {
            return new Job()
            {
                Id = Guid.Parse(Id),
                Title = Title,
                IsCompleted = IsCompleted
            };
        }
    }
}
