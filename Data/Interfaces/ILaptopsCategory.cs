using ShopLaptops.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopLaptops.Data.Interfaces
{
    public interface ILaptopsCategory
    {
        IEnumerable<Category> AllCategories { get; }
    }
}
