using ShopLaptops.Data.Interfaces;
using ShopLaptops.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopLaptops.Data.Mocks
{
    public class MockLaptops : IAllLaptops
    {
        private readonly ILaptopsCategory _categoryLaptops = new MockCategory();

        public IEnumerable<Laptop> Laptops 
        {
            get
            {
                return new List<Laptop>
                {
                    new Laptop {
                        Name = "ASUS ROG GX531G",
                        ShortDescription = "Gaming laptop",
                        LongDescription = "15,6' (1920x1080) IPS / Intel Core i7-8750H (2.2 - 4.1 ГГц) / RAM 16 ГБ / SSD 512 ГБ / Nvidia GeForce GTX 1070 / Bluetooth , Wi-Fi / Windows 10 / Без ОД",
                        Img = "/Img/Asus ROG.jpg",
                        Price = 39999,
                        IsFavorite = true,
                        IsAvaiable = true,
                        Category = _categoryLaptops.AllCategories.First() },

                    new Laptop {
                        Name = "Xiaomi Mi Notebook Pro 15.6",
                        ShortDescription = "High performance laptop",
                        LongDescription = "15,6' (1920x1080) IPS / Intel Core i7-8550U (1.8 - 4.0 ГГц) / RAM 8 ГБ / SSD 256 ГБ / nVidia GeForce MX150, 2 ГБ / Bluetooth , Wi-Fi / Windows 10 Home / Без ОД / 1.95 кг",
                        Img = "/Img/Xiaomi-Mi-Notebook-Pro-15-2020-Intel.jpg",
                        Price = 33122,
                        IsFavorite = true,
                        IsAvaiable = false,
                        Category = _categoryLaptops.AllCategories.First() },

                    new Laptop {
                        Name = "APPLE MacBook Air 13",
                        ShortDescription = "Office laptop",
                        LongDescription = "13.3' Retina (2560x1600) WQXGA, глянцевий / Apple M1 / RAM 8 ГБ / SSD 256 ГБ / Apple M1 Graphics / Wi-Fi / Bluetooth / macOS Big Sur / 1.29 кг",
                        Img = "/Img/MacBook Air.jpg",
                        Price = 35990,
                        IsFavorite = false,
                        IsAvaiable = true,
                        Category = _categoryLaptops.AllCategories.Last() },

                    new Laptop {
                        Name = "Huawei MateBook D 14",
                        ShortDescription = "Office laptop",
                        LongDescription = "14' IPS (1920х1080) Full HD, матовый / Intel Core i3-10110U (2.1 - 4.1 ГГц) / RAM 8 ГБ / SSD 256 ГБ / Intel UHD / без ОД / Wi-Fi / Bluetooth / веб-камера / Windows 10 Home / 1.38 кг",
                        Img = "/Img/Huawei d14.jpg",
                        Price = 16990,
                        IsFavorite = false,
                        IsAvaiable = false,
                        Category = _categoryLaptops.AllCategories.Last() },
                };
            }

            set => throw new NotImplementedException(); 
        }

        public IEnumerable<Laptop> GetFavotiteLaptops { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public Laptop GetObjectLaptop(int laptop_id)
        {
            throw new NotImplementedException();
        }
    }
}
