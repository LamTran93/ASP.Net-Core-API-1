using Application.Interfaces;
using ASP.Net_Core_API__1.DTO;
using Domain.Exceptions;
using Microsoft.AspNetCore.Mvc;

namespace ASP.Net_Core_API__1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TasksController : ControllerBase
    {
        private readonly IJobServices _jobServices;

        public TasksController(IJobServices jobServices)
        {
            _jobServices = jobServices;
        }

        [HttpGet]
        public IActionResult GetTasks()
        {
            var jobs = _jobServices.GetJobs().Select(job => new JobDTO(job)).ToList();
            return Ok(jobs);
        }

        [HttpGet("{id}")]
        public IActionResult GetTask(string id)
        {
            var job = _jobServices.GetById(id);
            if (job == null) return BadRequest();
            return Ok(new JobDTO(job));
        }

        [HttpPost]
        public IActionResult CreateTask(string job)
        {
            try
            {
                var newJob = _jobServices.Create(job);
                return CreatedAtAction("GetTask", new { id = newJob.Id.ToString() }, new JobDTO(newJob));
            }
            catch (InvalidJobException)
            {
                return BadRequest("Invalid job");
            }
            catch (ExistedException)
            {
                return Conflict("Job already exists");
            }
        }

        [HttpPut("{id}")]
        public IActionResult UpdateTask(string id, [FromBody] JobDTO job)
        {
            if (id != job.Id) return BadRequest("Id not matched");
            try
            {
                _jobServices.UpdateJob(id, job.ToJob());
                return NoContent();
            }
            catch (NotFoundException)
            {
                return NotFound();
            }
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteTask(string id)
        {
            try
            {
                _jobServices.Delete(id);
                return NoContent();
            }
            catch (NotFoundException)
            {
                return NotFound();
            }
        }

        [HttpPost("bulk")]
        public IActionResult CreateTasks([FromBody] List<string> jobs)
        {
            try
            {
                var addedJobs = _jobServices.CreateJobs(jobs);
                return Ok(addedJobs.Select(job => new JobDTO(job)).ToList());
            }
            catch (InvalidJobException ex)
            {
                return BadRequest($"Invalid job: {ex.Message}");
            }
            catch (ExistedException ex)
            {
                return Conflict($"Job already exists: {ex.Message}");
            }
            catch (DuplicatedJobException ex)
            {
                return BadRequest($"Duplicated job: {ex.Message}");
            }
        }

        [HttpDelete("bulk")]
        public IActionResult DeleteTasks([FromBody] List<string> idList)
        {
            _jobServices.DeleteJobs(idList);
            return NoContent();
        }
    }
}
