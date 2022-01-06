using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopLaptops.Data.Models
{
    public class OrderDetail
    {
        public int Id { get; set; }
        public int OrderId { get; set; }
        public int LaptopId { get; set; }
        public decimal Price { get; set; }
        public virtual Laptop _Laptop { get; set; }
        public virtual Order _Order { get; set; }
    }
}
