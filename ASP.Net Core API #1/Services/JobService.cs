using ASP.Net_Core_API__1.Exceptions;
using ASP.Net_Core_API__1.Interfaces.Repositories;
using ASP.Net_Core_API__1.Interfaces.Services;
using ASP.Net_Core_API__1.Models;

namespace ASP.Net_Core_API__1.Services
{
    public class JobService : IJobServices
    {
        private readonly IJobRepository _repository;

        public JobService(IJobRepository repository)
        {
            _repository = repository;
        }

        public void ChangeCompletionStatus(string id, bool isCompleted = true)
        {
            var job = _repository.GetById(id);
            if (job == null) throw new JobNotFoundException();
            job.IsCompleted = isCompleted;
        }

        public void ChangeTitle(string id, string newTitle)
        {
            var job = _repository.GetById(id);
            if (job == null) throw new JobNotFoundException();
            job.Title = newTitle;
        }

        public Job Create(string job)
        {
            var newJob = new Job() { Id = Guid.NewGuid(), Title = job, IsCompleted = false };
            _repository.Add(newJob);
            return newJob;
        }

        public List<Job> CreateJobs(List<string> jobs)
        {
            var addedJobs = jobs
                .Select(job => { return new Job() { Id = Guid.NewGuid(), Title = job, IsCompleted = false }; })
                .ToList();
            _repository.AddRange(addedJobs);
            return addedJobs;
        }

        public void Delete(string id)
        {
            _repository.Delete(id);
        }

        public void DeleteJobs(List<string> idList)
        {
            foreach (var id in idList)
            {
                try
                {
                    _repository.Delete(id);
                }
                catch { }
            }
        }

        public Job? GetById(string id)
        {
            return _repository.GetById(id);
        }

        public List<Job> GetJobs()
        {
            return _repository.GetJobs();
        }
    }
}
