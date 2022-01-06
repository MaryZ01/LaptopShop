using Microsoft.EntityFrameworkCore;
using ShopLaptops.Data.Interfaces;
using ShopLaptops.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopLaptops.Data.Repository
{
    public class LaptopRepository : IAllLaptops
    {
        private readonly AppDBContent AppDbContent;

        public LaptopRepository(AppDBContent appdbcontent)
        {
            AppDbContent = appdbcontent;
        }

        public IEnumerable<Laptop> Laptops => AppDbContent.Laptop_.Include(laptop => laptop.Category);

        public IEnumerable<Laptop> GetFavotiteLaptops => AppDbContent.Laptop_.Where(laptop => laptop.IsFavorite).Include(laptop => laptop.Category);

        public Laptop GetObjectLaptop(int laptop_id) => AppDbContent.Laptop_.FirstOrDefault(lap => lap.Id == laptop_id);
    }
}
