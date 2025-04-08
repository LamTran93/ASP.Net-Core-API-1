using Domain.Models;
using Domain.Exceptions;
using Application.Interfaces;

namespace Application.Services
{
    public class JobService(IJobRepository repository) : IJobServices
    {
        private readonly IJobRepository _repository = repository;

        public void UpdateJob(string id, Job job)
        {
            var existingJob = _repository.GetById(id) ?? throw new NotFoundException();
            existingJob.Title = job.Title;
            existingJob.IsCompleted = job.IsCompleted;
        }

        public Job Create(string job)
        {
            if (!IsValidated(job))
            {
                throw new InvalidException($"Job \"{job}\" is invalid");
            }
            if (IsExisted(job))
            {
                throw new ExistedException($"Job \"{job}\" is existed");
            }
            var newJob = new Job() { Id = Guid.NewGuid(), Title = job, IsCompleted = false };
            _repository.Add(newJob);
            return newJob;
        }

        public List<Job> CreateJobs(List<string> jobs)
        {
            var jobCount = new Dictionary<string, int>(StringComparer.OrdinalIgnoreCase);
            var addedJobs = jobs
                .Select(job =>
                {
                    if (!IsValidated(job))
                    {
                        throw new InvalidException($"Job \"{job}\" is invalid");
                    }
                    if (IsExisted(job))
                    {
                        throw new ExistedException($"Job \"{job}\" is existed");
                    }
                    jobCount.TryGetValue(job, out var count);
                    if (count > 0)
                        throw new DuplicatedException($"Job \"{job}\" is duplicated");
                    else jobCount.Add(job.Trim(), 1);
                    return new Job() { Id = Guid.NewGuid(), Title = job, IsCompleted = false };
                })
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

                catch
                { // Ignore if 1 job is not found
                }
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

        private bool IsExisted(string jobTitle)
        {
            var trimmedJobTitle = jobTitle.Trim();
            return _repository.Any(job => job.Title.Trim().Equals(trimmedJobTitle, StringComparison.OrdinalIgnoreCase));
        }

        private static bool IsValidated(string jobTitle)
        {
            return !string.IsNullOrEmpty(jobTitle) && jobTitle.Length > 3;
        }
    }
}
