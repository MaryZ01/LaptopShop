using Microsoft.AspNetCore.Mvc;
using ShopLaptops.Data;
using ShopLaptops.Data.Interfaces;
using ShopLaptops.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopLaptops.Controllers
{
    public class OrderController : Controller
    {
        private readonly IAllOrders AllOrders;
        private readonly ShopCart ShopCart;

        public OrderController(IAllOrders allorders, ShopCart shopcart)
        {
            AllOrders = allorders;
            ShopCart = shopcart;
        }

        public IActionResult Checkout()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Checkout(Order order)
        {
            ShopCart.ListCartItems = ShopCart.GetCartItems();

            if(ShopCart.ListCartItems.Count == 0)
            {
                ModelState.AddModelError("", "Корзина пуста");
            }

            if(ModelState.IsValid)
            {
                AllOrders.CreateOrder(order);
                return RedirectToAction("Complete");
            }

            return View(order);
        }

        public IActionResult Complete()
        {
            ViewBag.Message = "Замовлення в обробці";
            return View();
        }
    }
}
