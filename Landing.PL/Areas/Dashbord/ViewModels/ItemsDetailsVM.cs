namespace Landing.PL.Areas.Dashbord.ViewModels
{
    public class ItemsDetailsVM
    {
        public string Name { get; set; }

        public string Description { get; set; }
            public int Price { get; set; }
        public bool siDeleted { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
