using Domain.Models;
using Domain.Models.Enums;

namespace ASP.Net_Core_API__1.DTO
{
    public class PersonDTO
    {
        public string? Id { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public DateOnly? DateOfBirth { get; set; }
        public string? Gender { get; set; }
        public string? BirthPlace { get; set; }

        public PersonDTO()
        {

        }

        public PersonDTO(Person person)
        {
            Id = person.Id.ToString();
            FirstName = person.FirstName;
            LastName = person.LastName;
            DateOfBirth = person.DateOfBirth;
            Gender = person.Gender.ToString();
            BirthPlace = person.BirthPlace;
        }

        public Person ToPerson()
        {
            var idValid = Guid.TryParse(Id, out var id);
            return new Person
            {
                Id = idValid ? id : Guid.NewGuid(),
                FirstName = FirstName,
                LastName = LastName,
                DateOfBirth = DateOfBirth ?? DateOnly.MinValue,
                Gender = (Gender) Enum.Parse(typeof(Gender), Gender, true),
                BirthPlace = BirthPlace,
            };
        }

        public bool IsValidated()
        {
            return !(string.IsNullOrWhiteSpace(FirstName)
                || string.IsNullOrWhiteSpace(LastName)
                || DateOfBirth == null
                || !Enum.GetNames(typeof(Domain.Models.Enums.Gender)).Any(e => e.Contains(Gender, StringComparison.OrdinalIgnoreCase))
                || string.IsNullOrWhiteSpace(BirthPlace));
        }
    }
}
