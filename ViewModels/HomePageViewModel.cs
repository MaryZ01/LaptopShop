using ShopLaptops.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopLaptops.ViewModels
{
    public class HomePageViewModel
    {
        public IEnumerable<Laptop> favorite_laptops { get; set; }
    }
}
