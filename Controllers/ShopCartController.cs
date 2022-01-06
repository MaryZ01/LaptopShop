using Microsoft.AspNetCore.Mvc;
using ShopLaptops.Data.Interfaces;
using ShopLaptops.Data.Models;
using ShopLaptops.Data.Repository;
using ShopLaptops.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopLaptops.Controllers
{
    public class ShopCartController : Controller
    {
        private readonly IAllLaptops  laptop_repository;
        private readonly ShopCart shop_cart;

        public ShopCartController(IAllLaptops _laptop_rep, ShopCart _shop_cart)
        {
            laptop_repository = _laptop_rep;
            shop_cart = _shop_cart;
        }

        public ViewResult Index()
        {
            var items = shop_cart.GetCartItems();
            shop_cart.ListCartItems = items;

            var obj = new ShopCartViewModel { shopCart = shop_cart };

            return View(obj);
        }

        public RedirectToActionResult AddToCart(int id)
        {
            var item = laptop_repository.Laptops.FirstOrDefault(item => item.Id == id);
            if(item != null)
            {
                shop_cart.AddItemToCart(item);
            }

            return RedirectToAction("Index");
        }
    }
}
