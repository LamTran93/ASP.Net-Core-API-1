using Application.Interfaces;
using Application.Types;
using Domain.Exceptions;
using Domain.Models;

namespace Application.Services
{
    public class PersonService(IPersonRepository personRepository) : IPersonService
    {
        private readonly IPersonRepository _personRepository = personRepository;

        public void Add(Person person)
        {
            if (_personRepository.Any(p => p.LastName == person.LastName && p.DateOfBirth == person.DateOfBirth))
                throw new DuplicatedException("Person existed");
            person.Id = Guid.NewGuid();
            _personRepository.Add(person);
        }

        public void Delete(string id)
        {
            if (!_personRepository.Any(p => p.Id.ToString().Equals(id, StringComparison.OrdinalIgnoreCase)))
                throw new NotFoundException($"Person {id} not found");
            _personRepository.Delete(id);
        }

        public void Update(Person person)
        {
            if (!_personRepository.Any(p => p.Id.Equals(person.Id)))
                throw new NotFoundException($"Person {person.Id} not found");
            _personRepository.Update(person);
        }

        public List<Person> Filter(FilterOptions options)
        {
            IEnumerable<Person> result = _personRepository.GetPersons();

            if (options.NameFilter)
            {
                result = result.Where(p => p.FirstName.Contains(options.Name) || p.LastName.Contains(options.Name));
            }

            if (options.GenderFilter)
            {
                result = result.Where(p => p.Gender == options.Gender);
            }

            if (options.BirthPlaceFilter)
            {
                result = result.Where(p => p.BirthPlace.Contains(options.BirthPlace, StringComparison.OrdinalIgnoreCase));
            }

            return [.. result];
        }
    }
}
