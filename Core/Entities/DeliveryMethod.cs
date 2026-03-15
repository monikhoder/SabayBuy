using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities
{
    public class DeliveryMethod : BaseEntity
    {
        public required string ShortName { get; set; }
        public required string DeliveryTime { get; set; }
        public required string Description { get; set; }
        public string? Icon { get; set; }
        public decimal Price { get; set; }
        public List<string> AvailableZipcodes { get; set; } = new List<string>(); //Firs 2 digits of the zipcode to determine the region
    }
}
