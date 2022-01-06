using ShopLaptops.Data.Interfaces;
using ShopLaptops.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopLaptops.Data.Mocks
{
    public class MockCategory : ILaptopsCategory
    {
        public IEnumerable<Category> AllCategories
        {
            get
            {
                return new List<Category>
                {
                    new Category { Name = "Дискретна відеокарта", Description = "Ігрові"},
                    new Category { Name = "Інтегрована відеокарта", Description = "Офісні"}
                };
            }
        }
    }
}
