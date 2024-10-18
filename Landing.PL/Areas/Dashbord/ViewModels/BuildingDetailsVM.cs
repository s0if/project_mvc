namespace Landing.PL.Areas.Dashbord.ViewModels
{
    public class BuildingDetailsVM
    {
        public string DetailsBuilding { get; set; }
        public int Price { get; set; }
        public int Bedrooms { get; set; }
        public int bathrooms { get; set; }
        public int Area { get; set; }
        public int Floor { get; set; }
        public int Parking { get; set; }
        public bool siDeleted { get; set; }
        public DateTime CreatedAt { get; set; }
        public string Imageaname { get; set; }
    }
}
