using Application.Interfaces;
using Application.Types;
using Domain.Models;

namespace Application.Services
{
    public class PersonService : IPersonService
    {
        private IPersonRepository _personRepository;

        public PersonService(IPersonRepository personRepository)
        {
            _personRepository = personRepository;
        }

        public void Add(Person person)
        {
            _personRepository.Add(person);
        }

        public void Delete(string id)
        {
            _personRepository.Delete(id);
        }

        public void Update(Person person)
        {
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
                result = result.Where(p => p.BirthPlace.Contains(options.BirthPlace));
            }

            return [.. result];
        }
    }
}
