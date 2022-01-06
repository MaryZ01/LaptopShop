using Microsoft.EntityFrameworkCore;
using ShopLaptops.Data.Models;
using System;
using System.Collections.Generic;
//using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace ShopLaptops.Data
{
    public class AppDBContent : DbContext
    {
        public AppDBContent(DbContextOptions<AppDBContent> options) : base(options) { }

        public DbSet<Laptop> Laptop_ { get; set; }
        public DbSet<Category> Category_ { get; set; }

        public DbSet<ShopCartItem> ShopCartItem_ { get; set; }

        public DbSet<Order> Order_ { get; set; }
        public DbSet<OrderDetail> OrderDetail_ { get; set; }

    }
}
