using ShopLaptops.Data.Interfaces;
using ShopLaptops.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopLaptops.Data.Repository
{
    public class CategoryRepository : ILaptopsCategory
    {
        private readonly AppDBContent AppDbContent;

        public CategoryRepository(AppDBContent appdbcontent)
        {
            AppDbContent = appdbcontent;
        }

        public IEnumerable<Category> AllCategories => AppDbContent.Category_;
    }
}
