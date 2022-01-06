using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using ShopLaptops.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopLaptops.Data
{
    public class DBObjects
    {
        public static Dictionary<string, Category> category_Dict;

        public static Dictionary<string, Category> Categories               
        {
            get
            {
                if(category_Dict == null)
                {
                    var list = new Category[]
                    {
                        new Category { Name = "Дискретна відеокарта", Description = "Ігрові"},
                        new Category { Name = "Інтегрована відеокарта", Description = "Офісні"}
                    };

                    category_Dict = new Dictionary<string, Category>();
                    foreach(Category cat in list)
                    {
                        category_Dict.Add(cat.Name, cat);
                    }
                }

                return category_Dict;
            }
        }

        public static void Initial(AppDBContent content)                                         //кожен раз буде добавляти об'єкти в БД при старті програми
        {
            if (!content.Category_.Any())                                                                   //якщо пусто, то будемо добавляти об'єкти
            {
                content.Category_.AddRange(Categories.Select(c => c.Value));                
            }

            if (!content.Laptop_.Any())                                                                     //якщо пусто, то будемо добавляти об'єкти
            {
                content.AddRange(
                    new Laptop
                    {
                        Name = "ASUS ROG GX531G",
                        ShortDescription = "Gaming laptop",
                        LongDescription = "15,6' (1920x1080) IPS / Intel Core i7-8750H (2.2 - 4.1 ГГц) / RAM 16 ГБ / SSD 512 ГБ / Nvidia GeForce GTX 1070 / Bluetooth , Wi-Fi / Windows 10 / Без ОД",
                        Img = "/Img/Asus ROG.jpg",
                        Price = 39999,
                        IsFavorite = true,
                        IsAvaiable = true,
                        Category = Categories["Дискретна відеокарта"]
                    },

                    new Laptop
                    {
                        Name = "Xiaomi Mi Notebook Pro 15.6",
                        ShortDescription = "High performance laptop",
                        LongDescription = "15,6' (1920x1080) IPS / Intel Core i7-8550U (1.8 - 4.0 ГГц) / RAM 8 ГБ / SSD 256 ГБ / nVidia GeForce MX150, 2 ГБ / Bluetooth , Wi-Fi / Windows 10 Home / Без ОД / 1.95 кг",
                        Img = "/Img/Xiaomi-Mi-Notebook-Pro-15-2020-Intel.jpg",
                        Price = 33122,
                        IsFavorite = true,
                        IsAvaiable = false,
                        Category = Categories["Дискретна відеокарта"]
                    },

                    new Laptop
                    {
                        Name = "APPLE MacBook Air 13",
                        ShortDescription = "Office laptop",
                        LongDescription = "13.3' Retina (2560x1600) WQXGA, глянцевий / Apple M1 / RAM 8 ГБ / SSD 256 ГБ / Apple M1 Graphics / Wi-Fi / Bluetooth / macOS Big Sur / 1.29 кг",
                        Img = "/Img/MacBook Air.jpg",
                        Price = 35990,
                        IsFavorite = false,
                        IsAvaiable = true,
                        Category = Categories["Інтегрована відеокарта"]
                    },

                    new Laptop
                    {
                        Name = "Huawei MateBook D 14",
                        ShortDescription = "Office laptop",
                        LongDescription = "14' IPS (1920х1080) Full HD, матовый / Intel Core i3-10110U (2.1 - 4.1 ГГц) / RAM 8 ГБ / SSD 256 ГБ / Intel UHD / без ОД / Wi-Fi / Bluetooth / веб-камера / Windows 10 Home / 1.38 кг",
                        Img = "/Img/Huawei d14.jpg",
                        Price = 16990,
                        IsFavorite = false,
                        IsAvaiable = false,
                        Category = Categories["Інтегрована відеокарта"]
                    }
                ); 
            }

            content.SaveChanges();                                              //Щоб зберегти всі зміни в БД
        }

    }
}
