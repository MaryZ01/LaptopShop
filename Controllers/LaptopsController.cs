using Microsoft.AspNetCore.Mvc;
using ShopLaptops.Data.Interfaces;
using ShopLaptops.Data.Models;
using ShopLaptops.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopLaptops.Controllers
{
    public class LaptopsController : Controller
    {
        public readonly IAllLaptops allLaptops;
        public readonly ILaptopsCategory allCategories;

        public LaptopsController(IAllLaptops _iAllLaptops, ILaptopsCategory _iAllCategories)
        {
            allLaptops = _iAllLaptops;
            allCategories = _iAllCategories;
        }

        [Route("Laptops/List")]
        [Route("Laptops/List/{category}")]
        [Route("List/{category}")]
        public ViewResult List(string category)
        {
            string _category = category;
            IEnumerable<Laptop> laptops = null;
            string curr_category = "";

            if(string.IsNullOrEmpty(category))
            {
                laptops = allLaptops.Laptops.OrderBy(l => l.Id);
            }
            else
            {
                if (string.Equals("discrete", category, StringComparison.OrdinalIgnoreCase))
                {
                    laptops = allLaptops.Laptops.Where(l => l.Category.Name.Equals("Дискретна відеокарта")).OrderBy(l => l.Id);
                    curr_category = "Дискретна відеокарта";

                }
                else if(string.Equals("integrated", category, StringComparison.OrdinalIgnoreCase))
                {
                    laptops = allLaptops.Laptops.Where(l => l.Category.Name.Equals("Інтегрована відеокарта")).OrderBy(l => l.Id);
                    curr_category = "Дискретна відеокарта";
                }
            }

            var laptop_object = new LaptopsListViewModel
            {
                AllLaptops = laptops,
                current_category = curr_category
            };

            //ViewBag.Title("Сторінка з автомобілями");

            return View(laptop_object);
        }
    }
}
