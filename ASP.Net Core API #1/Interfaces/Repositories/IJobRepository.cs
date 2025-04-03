using ASP.Net_Core_API__1.Models;

namespace ASP.Net_Core_API__1.Interfaces.Repositories
{
    public interface IJobRepository
    {
        public void Add(Job newJob);
        public void AddRange(List<Job> newJobs);
        public List<Job> GetJobs();
        public Job? GetById(string id);
        public void Delete(string id);
        public void Update(Job updatedJob);
    }
}
