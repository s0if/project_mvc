using System.ComponentModel.DataAnnotations;

namespace Landing.PL.Areas.Dashbord.ViewModels
{
    public class BuildingFormVM
    {
        public Guid Id { get; set; }
        public string DetailsBuilding { get; set; }
        public int Price { get; set; }
        public int Bedrooms { get; set; }
        public int bathrooms { get; set; }
        public int Area { get; set; }
        public int Floor { get; set; }
        public int Parking { get; set; }
        public bool siDeleted { get; set; }
        public IFormFile image { get; set; }
        public string? Imageaname { get; set; }
    }
}
