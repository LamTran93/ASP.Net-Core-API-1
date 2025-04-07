using Domain.Models;

namespace Application.Interfaces
{
    public interface IPersonRepository
    {
        public void Add(Person newPerson);
        public void AddRange(List<Person> newPersons);
        public List<Person> GetPersons();
        public Person? GetById(string id);
        public void Delete(string id);
        public void Update(Person updatedPerson);
        public bool Any(Func<Person, bool> predicate);
    }
}
