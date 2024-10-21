using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Landing.DAL.Models
{
    public class Item
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool siDeleted { get; set; } = false;
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public Guid? IdBuilding { get; set; }
        public Building Building { get; set; }
    }
}
