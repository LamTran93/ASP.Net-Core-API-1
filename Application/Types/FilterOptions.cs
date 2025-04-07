using Domain.Models.Enums;

namespace Application.Types
{
    public class FilterOptions
    {
        public bool NameFilter { get; set; }
        public bool GenderFilter { get; set; }
        public bool BirthPlaceFilter { get; set; }
        public string Name { get; set; }
        public Gender Gender { get; set; }
        public string BirthPlace { get; set; }
    }
}
