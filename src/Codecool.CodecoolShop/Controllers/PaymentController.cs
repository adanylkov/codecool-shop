﻿using Codecool.CodecoolShop.Daos.Implementations;
using Codecool.CodecoolShop.Helpers;
using Codecool.CodecoolShop.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Codecool.CodecoolShop.Controllers
{
    public class PaymentController : Controller
    {
        private readonly ILogger<PaymentController> _logger;

        public PaymentController(ILogger<PaymentController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            var cart = HttpContext.Session.GetObjectFromJson<Cart>("cart");
            ViewData["total"] = cart?.Total(ProductDaoMemory.GetInstance()) ?? 0M;
            return View();
        }

        [HttpPost]
        public IActionResult Confirm()
        {
            var order = HttpContext.Session.GetObjectFromJson<Order>("order");
            order.SaveToJson();
            return Redirect("/confirmation");
        }
    }
}
