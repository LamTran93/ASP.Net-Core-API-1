using Application.Interfaces;
using Domain.Models;
using Domain.Exceptions;

namespace Infrastructure
{
    public class JobRepository : IJobRepository
    {
        private List<Job> _jobs;

        public JobRepository(List<Job> jobs)
        {
            _jobs = jobs;
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
