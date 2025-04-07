using Domain.Models.Enums;

namespace Domain.Models
{
    public class Person
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateOnly DateOfBirth { get; set; }
        public Gender Gender { get; set; }
        public string BirthPlace { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        public void CopyFrom(Person other)
        {
            Id = other.Id;
            FirstName = other.FirstName;
            LastName = other.LastName;
            DateOfBirth = other.DateOfBirth;
            Gender = other.Gender;
            BirthPlace = other.BirthPlace;
        }
    }
}
