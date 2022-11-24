using Codecool.CodecoolShop.Daos.Implementations;
using Codecool.CodecoolShop.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Codecool.CodecoolShop.Helpers;
using Codecool.CodecoolShop.Models;
using System.Linq;
using System.Text.Json;
using Newtonsoft.Json;

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

        private Cart getCart()
        {
            var cart = HttpContext.Session.GetObjectFromJson<Cart>("cart");
            cart ??= new Cart();
            return cart;
        }
        public IActionResult Index()
        {
            var cart = getCart();
            var cartContent = cart
                .GetAll()
                .Select(pair => (
                    ProductService.GetProductById(pair.Key),
                    pair.Value))
                .Select(pair => new {
                    pair.Item1.Name,
                    pair.Item1.Id,
                    Price = pair.Item1.DefaultPrice,
                    Quanity = pair.Item2,
                    ImagePath = $"img/{pair.Item1.Name}.jpg",
                }).ToArray();

            return Ok(cartContent);
        }

        public IActionResult Buy(int productId)
        {
            var cart = getCart();
            var product = ProductService.GetProductById(productId);
            cart.Add(product);
            HttpContext.Session.SetObjectAsJson("cart", cart);
            return Ok();
        }
        public IActionResult ChangeQuanity(int productId, int newAmount)
        {
            var cart = getCart();
            cart.SetQuanity(productId, newAmount);
            HttpContext.Session.SetObjectAsJson("cart", cart);
            return Ok();
        }
        public IActionResult Remove(int productId)
        {
            var cart = getCart();
            cart.Remove(productId);
            HttpContext.Session.SetObjectAsJson("cart", cart);
            return Ok();
        }
    }
}
