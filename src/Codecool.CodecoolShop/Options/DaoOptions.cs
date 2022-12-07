using Codecool.CodecoolShop.Daos;
using Codecool.CodecoolShop.Daos.Implementations;
using Codecool.CodecoolShop.Services;
using DataAccess;
using Domain;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace Codecool.CodecoolShop.Options
{
    public static class DaoOptions
    {
        public static void RegisterDao(IConfiguration configuration, IServiceCollection services)
        {
            var mode = configuration.GetRequiredSection("Mode");
            switch (mode.Value)
            {
                case "memory":
                    services.AddSingleton<IProductDao, ProductDaoMemory>();
                    services.AddSingleton<IProductCategoryDao, ProductCategoryDaoMemory>();
                    services.AddSingleton<ISupplierDao, SupplierDaoMemory>();
                    services.AddScoped<IProductService, ProductService>();
                    break;
                case "sql":
                    services.AddDbContext<ShopContext>(options => options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));
                    services.AddScoped<IProductDao, ProductDaoEF>();
                    services.AddScoped<IProductCategoryDao, ProductCategoryDaoEF>();
                    services.AddScoped<ISupplierDao, SupplierDaoEF>();
                    services.AddScoped<IProductService, ProductService>();
                    break;
                default:
                    throw new ArgumentException($"Unknown DAO mode");
            }
        }

        private static void AddMemoryProducts(IProductDao productDataStore, IProductCategoryDao productCategoryDataStore, ISupplierDao supplierDataStore)
        {
            Supplier amazon = new Supplier { Name = "Amazon", Description = "Digital content and services" };
            supplierDataStore.Add(amazon);
            Supplier lenovo = new Supplier { Name = "Lenovo", Description = "Computers" };
            supplierDataStore.Add(lenovo);
            Supplier asus = new Supplier { Name = "Asus", Description = "Computers" };
            supplierDataStore.Add(asus);
            Supplier samsung = new Supplier { Name = "Samsung", Description = "Mobile Phones" };
            supplierDataStore.Add(samsung);
            Supplier apple = new Supplier { Name = "Apple", Description = "Mobile Phones and Computers" };
            supplierDataStore.Add(apple);
            Supplier geForce = new Supplier { Name = "GeForce", Description = "Graphics card " };
            ProductCategory tablet = new ProductCategory { Name = "Tablet", Department = "Hardware", Description = "A tablet computer, commonly shortened to tablet, is a thin, flat mobile computer with a touchscreen display." };
            productCategoryDataStore.Add(tablet);
            productDataStore.Add(new Product { Name = "Amazon Fire", DefaultPrice = 49.9m, Currency = "USD", Description = "Fantastic price. Large content ecosystem. Good parental controls. Helpful technical support.", ProductCategory = tablet, Supplier = amazon });
            productDataStore.Add(new Product { Name = "Lenovo IdeaPad Miix 700", DefaultPrice = 479.0m, Currency = "USD", Description = "Keyboard cover is included. Fanless Core m5 processor. Full-size USB ports. Adjustable kickstand.", ProductCategory = tablet, Supplier = lenovo });
            productDataStore.Add(new Product { Name = "Amazon Fire HD 8", DefaultPrice = 89.0m, Currency = "USD", Description = "Amazon's latest Fire HD 8 tablet is a great value for media consumption.", ProductCategory = tablet, Supplier = amazon });
            ProductCategory laptop = new ProductCategory { Name = "Laptop", Department = "Hardware", Description = "A laptop computer is a battery- or AC-powered personal computer" };
            productCategoryDataStore.Add(laptop);
            productDataStore.Add(new Product { Name = "ASUS TUF Gaming", DefaultPrice = 650.0m, Currency = "USD", Description = "Bristling with high-refresh rate displays and competitive GPUs, ultra-durable TUF Gaming laptop deliver a reliable portable gaming experience to a wide audience of gamers.", ProductCategory = laptop, Supplier = asus });
            ProductCategory graphicsCard = new ProductCategory { Name = "Graphics card", Department = "Hardware", Description = "A Graphics card is an expansion card which generates a feed of output images to a display device, such as a computer monitor." };
            productCategoryDataStore.Add(graphicsCard);
            productDataStore.Add(new Product { Name = "Geforce RTX 3070", DefaultPrice = 510.0m, Currency = "USD", Description = "The Nvidia GeForce RTX 3070 is a fast desktop graphics card based on the Ampere architecture", ProductCategory = graphicsCard, Supplier = geForce });
            ProductCategory mobilePhone = new ProductCategory { Name = "Mobile Phone", Department = "Hardware", Description = "a telephone with access to a cellular radio system so it can be used over a wide area, without a physical connection to a network." };
            productCategoryDataStore.Add(mobilePhone);
            productDataStore.Add(new Product { Name = "Samsung Galaxy S22", DefaultPrice = 610.0m, Currency = "USD", Description = "Samsung Galaxy S22, the most affordable device in the company's 2022 flagship series, has flown under the radar", ProductCategory = mobilePhone, Supplier = samsung });
            productDataStore.Add(new Product { Name = "Iphone 14", DefaultPrice = 1115.0m, Currency = "USD", Description = "Iphone 14 has A15 Bionic, with a 5‑core GPU, powers all the latest features and makes graphically intense games and AR apps feel ultrafluid.", ProductCategory = mobilePhone, Supplier = apple });
            productDataStore.Add(new Product { Name = "ASUS ROG Phone 6", DefaultPrice = 999.0m, Currency = "USD", Description = "The ASUS ROG Phone 6 is an Android gaming smartphone made by Asus", ProductCategory = mobilePhone, Supplier = asus });
        }
    }
}
