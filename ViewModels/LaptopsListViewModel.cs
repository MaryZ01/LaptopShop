using ShopLaptops.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopLaptops.ViewModels
{
    public class LaptopsListViewModel
    {
        public IEnumerable<Laptop> AllLaptops { get; set; }
        public string current_category { get; set; }
    }
}
