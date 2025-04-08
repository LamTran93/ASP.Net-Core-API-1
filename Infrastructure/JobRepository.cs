using Application.Interfaces;
using Domain.Models;
using Domain.Exceptions;

namespace Infrastructure
{
    public class JobRepository(List<Job> jobs) : IJobRepository
    {
        private readonly List<Job> _jobs = jobs;

        public void Add(Job newJob)
        {
            _jobs.Add(newJob);
        }

        public void AddRange(List<Job> newJobs)
        {
            _jobs.AddRange(newJobs);
        }

        public List<Job> GetJobs() { return _jobs; }

        public Job? GetById(string id)
        {
            return _jobs.FirstOrDefault(job => job.Id.Equals(Guid.Parse(id)));
        }

        public void Update(Job updatedJob)
        {
            var job = _jobs.FirstOrDefault(job => job.Id.Equals(updatedJob.Id)) ?? throw new NotFoundException($"Job id {updatedJob.Id} not found");
            job.CopyFrom(updatedJob);
        }

        public void Delete(string id)
        {
            var job = _jobs.FirstOrDefault(job => job.Id.Equals(Guid.Parse(id))) ?? throw new NotFoundException($"Job id {id} not found");
            _jobs.Remove(job);
        }

        public bool Any(Func<Job, bool> predicate)
        {
            return _jobs.Any(predicate);
        }
    }
}
