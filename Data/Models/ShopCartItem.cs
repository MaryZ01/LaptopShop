using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopLaptops.Data.Models
{
    public class ShopCartItem
    {
        public int Id { get; set; }
        public Laptop LaptopItem { get; set; }
        public decimal PriceItem { get; set; }

        public string ItemIdInShopCart { get; set; }
    }
}
