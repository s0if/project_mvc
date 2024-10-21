using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Landing.DAL.Models
{
    public class Building
    {
        public Guid Id { get; set; }
        public string DetailsBuilding { get; set; }
        public int Price {  get; set; }
        public int Bedrooms { get; set; }
        public int bathrooms { get; set; }
        public int Area { get; set; }
        public int Floor { get; set; }
        public int Parking { get; set; }
        public bool siDeleted { get; set; } = false;
        public DateTime CreatedAt { get; set; }= DateTime.Now;
        public string Imageaname { get; set; }
        public IEnumerable<Item> Items { get; set; }
    }
}
