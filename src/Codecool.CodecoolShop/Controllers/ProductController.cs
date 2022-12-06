using System.Diagnostics;
using System.Linq;
using System;
using Codecool.CodecoolShop.Daos.Implementations;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Serilog;
using Codecool.CodecoolShop.Models;
using Codecool.CodecoolShop.Services;

namespace Codecool.CodecoolShop.Controllers
{
    public class ProductController : Controller
    {
        private readonly ILogger<ProductController> _logger;
        public ProductService ProductService { get; set; }

        public ProductController(ILogger<ProductController> logger)
        {
            _logger = logger;
            try
            {
                Log.Information("Creating Daos");
                ProductService = new ProductService(
                    ProductDaoMemory.GetInstance(),
                    ProductCategoryDaoMemory.GetInstance(),
                    SupplierDaoMemory.GetInstance());
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Creating DAOs error! ");
            }
        }

        public IActionResult Index(int? supplier, int? category)
        {
            var defaultCategory = 1;
            ViewData["Categories"] = ProductService.GetCategories();
            ViewData["Supliers"] = ProductService.GetSupliers();
            if (category.HasValue)
            {
                var categoryProducts = ProductService.GetProductsForCategory(category.Value);
                return View(categoryProducts.ToList());
            }
            else  if (supplier.HasValue)
            {
                var supplierProducts = ProductService.GetProductsForSupplier(supplier.Value);
                return View(supplierProducts.ToList());
            }
            category = defaultCategory;
            var defaultProducts = ProductService.GetProductsForCategory(category.Value);
            return View(defaultProducts.ToList());
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
