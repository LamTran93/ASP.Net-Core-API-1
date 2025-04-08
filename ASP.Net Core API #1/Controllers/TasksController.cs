using Application.Interfaces;
using ASP.Net_Core_API__1.DTO;
using Domain.Exceptions;
using Microsoft.AspNetCore.Mvc;

namespace ASP.Net_Core_API__1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class TasksController(IJobServices jobServices) : ControllerBase
    {
        private readonly IJobServices _jobServices = jobServices;

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetTasks()
        {
            var jobs = _jobServices.GetJobs().Select(job => new JobDTO(job)).ToList();
            return await Task.FromResult(Ok(jobs));
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetTask(string id)
        {
            var job = _jobServices.GetById(id);
            if (job == null) return BadRequest();
            return await Task.FromResult(Ok(new JobDTO(job)));
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status409Conflict)]
        public async Task<IActionResult> CreateTask(string job)
        {
            try
            {
                var newJob = _jobServices.Create(job);
                return await Task.FromResult(CreatedAtAction("GetTask", new { id = newJob.Id.ToString() }, new JobDTO(newJob)));
            }
            catch (InvalidException)
            {
                return BadRequest("Invalid job");
            }
            catch (ExistedException)
            {
                return Conflict("Job already exists");
            }
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> UpdateTask(string id, [FromBody] JobDTO job)
        {
            if (id != job.Id) return BadRequest("Id not matched");
            try
            {
                _jobServices.UpdateJob(id, job.ToJob());
                return await Task.FromResult(NoContent());
            }
            catch (NotFoundException)
            {
                return NotFound();
            }
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteTask(string id)
        {
            try
            {
                _jobServices.Delete(id);
                return await Task.FromResult(NoContent());
            }
            catch (NotFoundException)
            {
                return NotFound();
            }
        }

        [HttpPost("bulk")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status409Conflict)]
        public async Task<IActionResult> CreateTasks([FromBody] List<string> jobs)
        {
            try
            {
                var addedJobs = _jobServices.CreateJobs(jobs);
                return await Task.FromResult(Ok(addedJobs.Select(job => new JobDTO(job)).ToList()));
            }
            catch (InvalidException ex)
            {
                return BadRequest($"Invalid job: {ex.Message}");
            }
            catch (ExistedException ex)
            {
                return Conflict($"Job already exists: {ex.Message}");
            }
            catch (DuplicatedException ex)
            {
                return BadRequest($"Duplicated job: {ex.Message}");
            }
        }

        [HttpDelete("bulk")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> DeleteTasks([FromBody] List<string> idList)
        {
            _jobServices.DeleteJobs(idList);
            return await Task.FromResult(NoContent());
        }
    }
}
