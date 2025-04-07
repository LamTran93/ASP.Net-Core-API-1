using Application.Interfaces;
using Domain.Exceptions;
using Domain.Models;
using Domain.Models.Enums;

namespace Infrastructure
{
    public class PersonRepository : IPersonRepository
    {
        private List<Person> _persons;

        public PersonRepository()
        {
            _persons = [
                new Person { Id = Guid.NewGuid(), FirstName = "John", LastName = "Doe", DateOfBirth = new DateOnly(1990, 1, 1), Gender = Gender.Male, BirthPlace = "New York" },
                new Person { Id = Guid.NewGuid(), FirstName = "Jane", LastName = "Doe", DateOfBirth = new DateOnly(1991, 2, 2), Gender = Gender.Female, BirthPlace = "Los Angeles" },
                new Person { Id = Guid.NewGuid(), FirstName = "Michael", LastName = "Smith", DateOfBirth = new DateOnly(1985, 3, 3), Gender = Gender.Male, BirthPlace = "Chicago" },
                new Person { Id = Guid.NewGuid(), FirstName = "Emily", LastName = "Johnson", DateOfBirth = new DateOnly(1988, 4, 4), Gender = Gender.Female, BirthPlace = "Houston" },
                new Person { Id = Guid.NewGuid(), FirstName = "David", LastName = "Williams", DateOfBirth = new DateOnly(1992, 5, 5), Gender = Gender.Male, BirthPlace = "Phoenix" },
                new Person { Id = Guid.NewGuid(), FirstName = "Sarah", LastName = "Brown", DateOfBirth = new DateOnly(1993, 6, 6), Gender = Gender.Female, BirthPlace = "Philadelphia" },
                new Person { Id = Guid.NewGuid(), FirstName = "James", LastName = "Jones", DateOfBirth = new DateOnly(1987, 7, 7), Gender = Gender.Male, BirthPlace = "San Antonio" },
                new Person { Id = Guid.NewGuid(), FirstName = "Jessica", LastName = "Garcia", DateOfBirth = new DateOnly(1989, 8, 8), Gender = Gender.Female, BirthPlace = "San Diego" },
                new Person { Id = Guid.NewGuid(), FirstName = "Robert", LastName = "Martinez", DateOfBirth = new DateOnly(1994, 9, 9), Gender = Gender.Male, BirthPlace = "Dallas" },
                new Person { Id = Guid.NewGuid(), FirstName = "Linda", LastName = "Rodriguez", DateOfBirth = new DateOnly(1995, 10, 10), Gender = Gender.Female, BirthPlace = "San Jose" },
                new Person { Id = Guid.NewGuid(), FirstName = "William", LastName = "Hernandez", DateOfBirth = new DateOnly(1986, 11, 11), Gender = Gender.Male, BirthPlace = "Austin" },
                new Person { Id = Guid.NewGuid(), FirstName = "Barbara", LastName = "Lopez", DateOfBirth = new DateOnly(1984, 12, 12), Gender = Gender.Female, BirthPlace = "Jacksonville" },
                new Person { Id = Guid.NewGuid(), FirstName = "Charles", LastName = "Gonzalez", DateOfBirth = new DateOnly(1996, 1, 13), Gender = Gender.Male, BirthPlace = "Fort Worth" },
                new Person { Id = Guid.NewGuid(), FirstName = "Susan", LastName = "Wilson", DateOfBirth = new DateOnly(1997, 2, 14), Gender = Gender.Female, BirthPlace = "Columbus" },
                new Person { Id = Guid.NewGuid(), FirstName = "Joseph", LastName = "Anderson", DateOfBirth = new DateOnly(1983, 3, 15), Gender = Gender.Male, BirthPlace = "Charlotte" },
                new Person { Id = Guid.NewGuid(), FirstName = "Karen", LastName = "Thomas", DateOfBirth = new DateOnly(1982, 4, 16), Gender = Gender.Female, BirthPlace = "San Francisco" },
                new Person { Id = Guid.NewGuid(), FirstName = "Thomas", LastName = "Taylor", DateOfBirth = new DateOnly(1998, 5, 17), Gender = Gender.Male, BirthPlace = "Indianapolis" },
                new Person { Id = Guid.NewGuid(), FirstName = "Nancy", LastName = "Moore", DateOfBirth = new DateOnly(1999, 6, 18), Gender = Gender.Female, BirthPlace = "Seattle" },
                new Person { Id = Guid.NewGuid(), FirstName = "Christopher", LastName = "Jackson", DateOfBirth = new DateOnly(1981, 7, 19), Gender = Gender.Male, BirthPlace = "Denver" },
                new Person { Id = Guid.NewGuid(), FirstName = "Betty", LastName = "Martin", DateOfBirth = new DateOnly(1980, 8, 20), Gender = Gender.Female, BirthPlace = "Washington" }
            ];
        }

        public void Add(Person person)
        {
            person.CreatedAt = DateTime.Now;
            person.UpdatedAt = DateTime.Now;
            _persons.Add(person);
        }

        public void AddRange(List<Person> persons)
        {
            foreach (Person person in persons)
            {
                person.CreatedAt = DateTime.Now;
                person.UpdatedAt = DateTime.Now;
            }
            _persons.AddRange(persons);
        }

        public List<Person> GetPersons() { return _persons; }

        public Person? GetById(string id)
        {
            return _persons.FirstOrDefault(p => p.Id.Equals(Guid.Parse(id)));
        }

        public void Update(Person updatedPerson)
        {
            var person = _persons.FirstOrDefault(p => p.Id.Equals(updatedPerson.Id));
            if (person == null) throw new NotFoundException($"Person #{updatedPerson.Id} not found");
            person.CopyFrom(updatedPerson);
            person.UpdatedAt = DateTime.Now;
        }

        public void Delete(string id)
        {
            var person = _persons.FirstOrDefault(p => p.Id.Equals(Guid.Parse(id)));
            if (person == null) throw new NotFoundException($"Person #{id} not found");
            _persons.Remove(person);
        }

        public bool Any(Func<Person, bool> predicate)
        {
            return _persons.Any(predicate);
        }
    }
}
