using Application.Interfaces;
using Application.Types;
using ASP.Net_Core_API__1.DTO;
using Domain.Exceptions;
using Domain.Models.Enums;
using Microsoft.AspNetCore.Mvc;

namespace ASP.Net_Core_API__1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class PersonsController(IPersonService personService) : ControllerBase
    {
        private readonly IPersonService _personService = personService;

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> AddPerson([FromBody] PersonDTO dto)
        {
            try
            {
                if (!dto.IsValidated())
                    return BadRequest("Person data is invalid");
                var person = dto.ToPerson();
                _personService.Add(person);
                return await Task.FromResult(Ok(person));
            }
            catch (DuplicatedException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception)
            {
                return BadRequest("Person data parsing failed");
            }
        }

        [HttpPut]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> UpdatePerson([FromBody] PersonDTO dto)
        {
            try
            {
                if (!dto.IsValidated())
                    return BadRequest("Person data is invalid");
                var person = dto.ToPerson();
                _personService.Update(person);
                return await Task.FromResult(NoContent());
            }
            catch (NotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception)
            {
                return BadRequest("Person data parsing failed");
            }
        }

        [HttpDelete]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeletePerson([FromBody] string id)
        {
            try
            {
                _personService.Delete(id);
                return await Task.FromResult(NoContent());
            }
            catch (NotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpGet("filter")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> Filter(
            [FromQuery] string? name,
            [FromQuery] string? gender,
            [FromQuery] string? birthPlace
            )
        {
            var options = new FilterOptions();

            if (!string.IsNullOrWhiteSpace(name))
            {
                options.Name = name.Trim();
                options.NameFilter = true;
            }

            if (!string.IsNullOrWhiteSpace(gender))
            {
                if (!Enum.TryParse(typeof(Gender), gender.Trim(), true, out var parsedGender))
                    return BadRequest($"Gender {gender} is invalid");
                options.Gender = (Gender)parsedGender;
                options.GenderFilter = true;
            }

            if (!string.IsNullOrWhiteSpace(birthPlace))
            {
                options.BirthPlace = birthPlace.Trim();
                options.BirthPlaceFilter = true;
            }

            var filteredPersons = _personService.Filter(options).Select(p => new PersonDTO(p));
            return await Task.FromResult(Ok(filteredPersons));
        }
    }
}
