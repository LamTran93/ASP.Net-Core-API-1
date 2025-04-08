using Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ASP.Net_Core_API__1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonsController : ControllerBase
    {
        private readonly IPersonService _personService;

        public PersonsController(IPersonService personService)
        {
            _personService = personService;
        }


    }
}
