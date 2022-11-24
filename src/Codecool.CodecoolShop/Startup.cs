using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Codecool.CodecoolShop.Daos;
using Codecool.CodecoolShop.Daos.Implementations;
using Codecool.CodecoolShop.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Codecool.CodecoolShop
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();
            services.AddSession();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Product/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();
            app.UseSession();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Product}/{action=Index}/{id?}");
            });

            SetupInMemoryDatabases();
        }

        private void SetupInMemoryDatabases()
        {
            IProductDao productDataStore = ProductDaoMemory.GetInstance();
            IProductCategoryDao productCategoryDataStore = ProductCategoryDaoMemory.GetInstance();
            ISupplierDao supplierDataStore = SupplierDaoMemory.GetInstance();

            Supplier amazon = new Supplier{Name = "Amazon", Description = "Digital content and services"};
            supplierDataStore.Add(amazon);
            Supplier lenovo = new Supplier{Name = "Lenovo", Description = "Computers"};
            supplierDataStore.Add(lenovo);
            Supplier asus = new Supplier { Name = "Asus", Description = "Computers" };
            supplierDataStore.Add(asus);
            Supplier samsung = new Supplier { Name = "Samsung", Description = "Mobile Phones" };
            supplierDataStore.Add(samsung);
            Supplier apple = new Supplier { Name = "Apple", Description = "Mobile Phones and Computers" };
            supplierDataStore.Add(apple);
            Supplier geForce = new Supplier { Name = "GeForce", Description = "Graphics card " };
            ProductCategory tablet = new ProductCategory {Name = "Tablet", Department = "Hardware", Description = "A tablet computer, commonly shortened to tablet, is a thin, flat mobile computer with a touchscreen display." };
            productCategoryDataStore.Add(tablet);
            productDataStore.Add(new Product { Name = "Amazon Fire", DefaultPrice = 49.9m, Currency = "USD", Description = "Fantastic price. Large content ecosystem. Good parental controls. Helpful technical support.", ProductCategory = tablet, Supplier = amazon });
            productDataStore.Add(new Product { Name = "Lenovo IdeaPad Miix 700", DefaultPrice = 479.0m, Currency = "USD", Description = "Keyboard cover is included. Fanless Core m5 processor. Full-size USB ports. Adjustable kickstand.", ProductCategory = tablet, Supplier = lenovo });
            productDataStore.Add(new Product { Name = "Amazon Fire HD 8", DefaultPrice = 89.0m, Currency = "USD", Description = "Amazon's latest Fire HD 8 tablet is a great value for media consumption.", ProductCategory = tablet, Supplier = amazon });
            ProductCategory laptop = new ProductCategory { Name = "Laptop", Department = "Hardware", Description = "A laptop computer is a battery- or AC-powered personal computer" };
            productCategoryDataStore.Add(laptop);
            productDataStore.Add(new Product { Name = "ASUS TUF Gaming", DefaultPrice = 650.0m, Currency = "USD", Description = "Bristling with high-refresh rate displays and competitive GPUs, ultra-durable TUF Gaming laptop deliver a reliable portable gaming experience to a wide audience of gamers.", ProductCategory = laptop, Supplier = asus });
            ProductCategory graphicsCard = new ProductCategory { Name = "Graphics card", Department = "Hardware", Description = "A Graphics card is an expansion card which generates a feed of output images to a display device, such as a computer monitor." };
            productCategoryDataStore.Add(graphicsCard);
            productDataStore.Add(new Product { Name = "Geforce RTX 3070", DefaultPrice = 510.0m, Currency = "USD", Description = "The Nvidia GeForce RTX 3070 is a fast desktop graphics card based on the Ampere architecture" , ProductCategory = graphicsCard, Supplier = geForce});
            ProductCategory mobilePhone = new ProductCategory { Name = "Mobile Phone", Department = "Hardware", Description = "a telephone with access to a cellular radio system so it can be used over a wide area, without a physical connection to a network." };
            productCategoryDataStore.Add(mobilePhone);
            productDataStore.Add(new Product { Name = "Samsung Galaxy S22", DefaultPrice = 610.0m, Currency = "USD", Description = "Samsung Galaxy S22, the most affordable device in the company's 2022 flagship series, has flown under the radar", ProductCategory = mobilePhone, Supplier = samsung });
            productDataStore.Add(new Product { Name = "Iphone 14", DefaultPrice = 1115.0m, Currency = "USD", Description = "Iphone 14 has A15 Bionic, with a 5‑core GPU, powers all the latest features and makes graphically intense games and AR apps feel ultrafluid.", ProductCategory = mobilePhone, Supplier = apple });
            productDataStore.Add(new Product { Name = "ASUS ROG Phone 6", DefaultPrice = 999.0m, Currency = "USD", Description = "The ASUS ROG Phone 6 is an Android gaming smartphone made by Asus", ProductCategory = mobilePhone, Supplier = asus });
        }
    }
}
