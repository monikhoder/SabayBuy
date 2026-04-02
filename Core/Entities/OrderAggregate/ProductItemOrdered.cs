using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities.OrderAggregate
{
    public class ProductItemOrdered
    {
        public Guid ProductId { get; set; }
        public required string ProductName { get; set; }
        public string ImageUrl { get; set; }

    }
}
