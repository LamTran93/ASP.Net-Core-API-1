using Domain.Models;

namespace Application.Interfaces
{
    public interface IJobRepository
    {
        public void Add(Job newJob);
        public void AddRange(List<Job> newJobs);
        public List<Job> GetJobs();
        public Job? GetById(string id);
        public void Delete(string id);
        public void Update(Job updatedJob);
        public bool Any(Func<Job, bool> predicate);
    }
}
