using Codecool.CodecoolShop.Daos.Implementations;
using Codecool.CodecoolShop.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Codecool.CodecoolShop.Helpers;
using System.Collections.Generic;
using Codecool.CodecoolShop.Models;

namespace Codecool.CodecoolShop.Controllers
{
    public class ShoppingCartController : Controller
    {
        private readonly ILogger<ShoppingCartController> _logger;

        public ProductService ProductService { get; set; }

        public ShoppingCartController(ILogger<ShoppingCartController> logger)
        {
            _logger = logger;
            ProductService = new ProductService(
                ProductDaoMemory.GetInstance(),
                ProductCategoryDaoMemory.GetInstance(),
                SupplierDaoMemory.GetInstance());
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult BuyProduct(int productId)
        {
            var cart = HttpContext.Session.GetObjectFromJson<Cart>("cart");
            if (cart == null) {
                cart = new Cart();
            }
            var product = ProductService.GetProductById(productId);
            cart.Add(product);
            return Ok();
        }

    }
}
