using Domain.Models;
using Application.Types;

namespace Application.Interfaces
{
    public interface IPersonService
    {
        public void Add(Person person);
        public void Update(Person person);
        public void Delete(string id);
        public List<Person> Filter(FilterOptions options);
    }
}
