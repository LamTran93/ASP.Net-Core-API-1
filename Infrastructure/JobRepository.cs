using Application.Interfaces;
using Domain.Models;
using Domain.Exceptions;

namespace Infrastructure
{
    public class JobRepository : IJobRepository
    {
        private List<Job> _jobs;

        public JobRepository()
        {
            _jobs = [
                new Job(){ Id = Guid.NewGuid(), Title = "Task number 1", IsCompleted = false},
                new Job(){ Id = Guid.NewGuid(), Title = "Task number 2", IsCompleted = false},
                new Job(){ Id = Guid.NewGuid(), Title = "Task number 3", IsCompleted = false},
                new Job(){ Id = Guid.NewGuid(), Title = "Task number 4", IsCompleted = false},
                new Job(){ Id = Guid.NewGuid(), Title = "Task number 5", IsCompleted = false},
                new Job(){ Id = Guid.NewGuid(), Title = "Task number 6", IsCompleted = false},
                new Job(){ Id = Guid.NewGuid(), Title = "Task number 7", IsCompleted = false},
                new Job(){ Id = Guid.NewGuid(), Title = "Task number 8", IsCompleted = false},
                new Job(){ Id = Guid.NewGuid(), Title = "Task number 9", IsCompleted = false},
                new Job(){ Id = Guid.NewGuid(), Title = "Task number 10", IsCompleted = false}
                ];
        }

        public void Add(Job job)
        {
            _jobs.Add(job);
        }

        public void AddRange(List<Job> jobs)
        {
            _jobs.AddRange(jobs);
        }

        public List<Job> GetJobs() { return _jobs; }

        public Job? GetById(string id)
        {
            return _jobs.FirstOrDefault(job => job.Id.Equals(Guid.Parse(id)));
        }

        public void Update(Job updatedJob)
        {
            var job = _jobs.FirstOrDefault(job => job.Id.Equals(updatedJob.Id));
            if (job == null) throw new NotFoundException($"Job id {updatedJob.Id} not found");
            job.CopyFrom(updatedJob);
        }

        public void Delete(string id)
        {
            var job = _jobs.FirstOrDefault(job => job.Id.Equals(Guid.Parse(id)));
            if (job == null) throw new NotFoundException($"Job id {id} not found");
            _jobs.Remove(job);
        }

        public bool Any(Func<Job, bool> predicate)
        {
            return _jobs.Any(predicate);
        }
    }
}
