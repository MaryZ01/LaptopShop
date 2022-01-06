using ShopLaptops.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopLaptops.Data.Interfaces
{
    public interface IAllLaptops
    {
        IEnumerable<Laptop> Laptops { get; }
        IEnumerable<Laptop> GetFavotiteLaptops { get; }

        Laptop GetObjectLaptop(int laptop_id);
    }
}
