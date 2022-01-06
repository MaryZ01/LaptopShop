using ShopLaptops.Data.Interfaces;
using ShopLaptops.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopLaptops.Data.Repository
{
    public class OrdersRepository : IAllOrders
    {
        private readonly AppDBContent appDbContent;
        private readonly ShopCart shopCart;

        public OrdersRepository(AppDBContent appdbcont, ShopCart shopcart)
        {
            appDbContent = appdbcont;
            shopCart = shopcart;
        }

        public void CreateOrder(Order order)
        {
            order.OrderTime = DateTime.Now;
            appDbContent.Order_.Add(order);
            var items = shopCart.ListCartItems;

            foreach(var el in items)
            {
                var orderDetail = new OrderDetail()
                {
                    LaptopId = el.LaptopItem.Id,
                    OrderId = order.Id,
                    Price = el.LaptopItem.Price
                };

                appDbContent.OrderDetail_.Add(orderDetail);
            }

            appDbContent.SaveChanges();
        }
    }
}
