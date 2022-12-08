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
        public static void RegisterDao(this IServiceCollection services, IConfiguration configuration)
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
    }
}
