using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopLaptops.Data.Models
{
    public class Laptop 
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ShortDescription { get; set; }
        public string LongDescription { get; set; }
        public string Img { get; set; }
        public decimal Price { get; set; }
        public bool IsFavorite { get; set; }
        public bool IsAvaiable { get; set; }
        public int CategoryId { get; set; }
        public virtual Category Category { get; set; }
    }
}
