using Domain.Models;

namespace Application.Interfaces
{
    public interface IJobServices
    {
        public List<Job> GetJobs();
        public Job? GetById(string id);
        public Job Create(string job);
        public void UpdateJob(string id, Job job);
        public void Delete(string id);
        public List<Job> CreateJobs(List<string> jobs);
        public void DeleteJobs(List<string> idList);
    }
}
