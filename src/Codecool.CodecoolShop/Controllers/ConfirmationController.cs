using Codecool.CodecoolShop.Daos;
using Codecool.CodecoolShop.Daos.Implementations;
using Codecool.CodecoolShop.Helpers;
using Codecool.CodecoolShop.Models;
using Codecool.CodecoolShop.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Codecool.CodecoolShop.Controllers
{
    public class ConfirmationController : Controller
    {
        private readonly IEmailService _emailService;
        private readonly IProductDao _productDao = ProductDaoMemory.GetInstance();
        public ConfirmationController(IEmailService emailService)
        {
            _emailService = emailService;
        }
        public IActionResult Index()
        {
            var order = HttpContext.Session.GetObjectFromJson<Order>("order");
            var cart = HttpContext.Session.GetObjectFromJson<Cart>("cart");
            if (order is not null)
            {
                var productQuanityPairs = cart.GetAll().Select(cartItem => new KeyValuePair<Product, int>(_productDao.Get(cartItem.Key), cartItem.Value));
                _emailService.SendConfirmationEmail(order.email, order.name, productQuanityPairs);
            }
            return View(order);
        }
    }
}
