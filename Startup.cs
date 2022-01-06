using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using ShopLaptops.Data;
using ShopLaptops.Data.Interfaces;
using ShopLaptops.Data.Mocks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ShopLaptops.Data.Repository;
using ShopLaptops.Data.Models;

namespace ShopLaptops
{
    public class Startup
    {
        private IConfigurationRoot conf_string;                                 

        public Startup(IHostEnvironment host_env)
        {
            //�������� dbsettings.json � ����� confstring
            conf_string = new ConfigurationBuilder().SetBasePath(host_env.ContentRootPath).AddJsonFile("dbsettings.json").Build();
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<AppDBContent>(options => options.UseSqlServer(conf_string.GetConnectionString("DefaultConnection"))); //�������, ���� ��������� sqlserver 

            services.AddTransient<ILaptopsCategory, CategoryRepository>();                                                              //��'���� ��������� � ����, ���� ���� ������
            services.AddTransient<IAllLaptops, LaptopRepository>();
            services.AddTransient<IAllOrders, OrdersRepository>();

            //services.AddSingleton<HttpContextAccessor, HttpContextAccessor>();
            services.AddSingleton<Microsoft.AspNetCore.Http.IHttpContextAccessor, Microsoft.AspNetCore.Http.HttpContextAccessor>();

            services.AddScoped(sp => ShopCart.GetCart(sp));                                                                             //���� ��� ����������� �������� � �������, �� ��� ���� ���� ���� �������

            services.AddMvc(option => option.EnableEndpointRouting = false);
            services.AddMemoryCache();
            services.AddSession();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseSession();
            app.UseDeveloperExceptionPage();                                                                                                        //����� ���������� ������� � ���������
            app.UseStatusCodePages();                                                                                                               //��� ���������� ���� �������(200,404,..)
            app.UseStaticFiles();                                                                                                                   //��� ���������� ������� �����(��������,css,..)                                  
            //app.UseMvcWithDefaultRoute();    //����� url-������ �� ������.

            app.UseMvc(routes =>
            {
                routes.MapRoute(name: "default", template: "{controller=Home}/{action=Index}/{id?}");
                routes.MapRoute(name: "categoryFilter", template: "{Laptop}/{action}/{category?}",
                    defaults: new { Controller = "Laptop", Action = "List" });
            });

            using (var scope = app.ApplicationServices.CreateScope())                                                                           //��������� ������, ��� ����� ���� ��������� ��� (�� ���� ����������� � ������)
            {
                AppDBContent content = scope.ServiceProvider.GetRequiredService<AppDBContent>();                                                //ϳ��������� �� AppDBContent �� ����������� � ��������� � �� � ��� ����� �����
                DBObjects.Initial(content);
            }
        }
    }
}
