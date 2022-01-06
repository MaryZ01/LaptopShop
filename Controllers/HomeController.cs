using Microsoft.AspNetCore.Mvc;
using ShopLaptops.Data.Interfaces;
using ShopLaptops.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopLaptops.Controllers
{
    public class HomeController : Controller
    {
        private readonly IAllLaptops laptop_repository;

        public HomeController(IAllLaptops _laptop_rep)
        {
            laptop_repository = _laptop_rep;
        }

        public ViewResult Index()
        {
            var home_page_laptops = new HomePageViewModel
            {
                favorite_laptops = laptop_repository.GetFavotiteLaptops
            };

            return View(home_page_laptops);                                          //на головній сторінці буду відображати тільки ті товари, в котрих IsFavorite == true
        }
    }
}
