using Application.Interfaces;
using Domain.Exceptions;
using Domain.Models;

namespace Infrastructure
{
    public class PersonRepository(List<Person> persons) : IPersonRepository
    {
        private readonly List<Person> _persons = persons;

        public void Add(Person newPerson)
        {
            newPerson.CreatedAt = DateTime.Now;
            newPerson.UpdatedAt = DateTime.Now;
            _persons.Add(newPerson);
        }

        public void AddRange(List<Person> newPersons)
        {
            foreach (Person person in newPersons)
            {
                person.CreatedAt = DateTime.Now;
                person.UpdatedAt = DateTime.Now;
            }
            _persons.AddRange(newPersons);
        }

        public List<Person> GetPersons() { return _persons; }

        public Person? GetById(string id)
        {
            return _persons.FirstOrDefault(p => p.Id.Equals(Guid.Parse(id)));
        }

        public void Update(Person updatedPerson)
        {
            var person = _persons.FirstOrDefault(p => p.Id.Equals(updatedPerson.Id)) ?? throw new NotFoundException($"Person #{updatedPerson.Id} not found");
            person.CopyFrom(updatedPerson);
            person.UpdatedAt = DateTime.Now;
        }

        public void Delete(string id)
        {
            var person = _persons.FirstOrDefault(p => p.Id.Equals(Guid.Parse(id))) ?? throw new NotFoundException($"Person #{id} not found");
            _persons.Remove(person);
        }

        public bool Any(Func<Person, bool> predicate)
        {
            return _persons.Any(predicate);
        }
    }
}
