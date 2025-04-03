using ASP.Net_Core_API__1.Interfaces.Services;
using ASP.Net_Core_API__1.Models;
using Microsoft.AspNetCore.Http;
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
            return Ok(_jobServices.GetJobs());
        }

        [HttpGet("{id}")]
        public IActionResult GetTask(string id)
        {
            var job = _jobServices.GetById(id);
            if (job == null) return BadRequest();
            return Ok(job);
        }

        [HttpPost]
        public IActionResult CreateTask(Job job)
        {
            var job = _jobServices.Create(job)
        }
    }
}
