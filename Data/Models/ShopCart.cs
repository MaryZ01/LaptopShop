using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopLaptops.Data.Models
{
    public class ShopCart
    {
        private readonly AppDBContent AppDbContent;

        public ShopCart(AppDBContent appdbcontent)
        {
            AppDbContent = appdbcontent;
        }

        public string ItemIdInShopCart { get; set; }
        public List<ShopCartItem> ListCartItems { get; set; }

        public static ShopCart GetCart(IServiceProvider service)
        {
            ISession session = service.GetRequiredService<IHttpContextAccessor>()?.HttpContext.Session;     //створення нової сесії
            var context = service.GetService<AppDBContent>();
            string ShopCartId = session.GetString("ItemIdInShopCart") ?? Guid.NewGuid().ToString();
            session.SetString("ItemIdInShopCart", ShopCartId);

            return new ShopCart(context)
            {
                ItemIdInShopCart = ShopCartId
            };            
        }

        public void AddItemToCart(Laptop laptop)
        {
            AppDbContent.ShopCartItem_.Add(new ShopCartItem 
            {
                ItemIdInShopCart = ItemIdInShopCart,
                LaptopItem = laptop,
                PriceItem = laptop.Price
            });

            AppDbContent.SaveChanges();
        }

        public List<ShopCartItem> GetCartItems()
        {
            return AppDbContent.ShopCartItem_.Where(lt => lt.ItemIdInShopCart == ItemIdInShopCart)
                .Include(s => s.LaptopItem).ToList();
        }
    }
}
