using Landing.DAL.Models;
using System.ComponentModel.DataAnnotations;

namespace Landing.PL.Areas.Dashbord.ViewModels
{
    public class ItemsFormVM
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool siDeleted { get; set; }
        public Guid? BuildingId { get; set; }
        public IEnumerable<BuildingVM> Buildings { get; set; }
    }
}
