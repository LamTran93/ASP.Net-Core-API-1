using ASP.Net_Core_API__1.Models;

namespace ASP.Net_Core_API__1.Interfaces.Services
{
    public interface IJobServices
    {
        public List<Job> GetJobs();
        public Job? GetById(string id);
        public Job Create(string job);
        public void ChangeTitle(string id, string newTitle);
        public void ChangeCompletionStatus(string id, bool status = true);
        public void Delete(string id);
        public List<Job> CreateJobs(List<string> jobs);
        public void DeleteJobs(List<string> idList);
    }
}
