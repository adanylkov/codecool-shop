using Codecool.CodecoolShop.Daos.Implementations;
using Codecool.CodecoolShop.Helpers;
using Codecool.CodecoolShop.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Hosting;
using System.IO;
using System;
using Serilog;
namespace Codecool.CodecoolShop.Controllers
{
    public class PaymentController : Controller
    {
        private readonly ILogger<PaymentController> _logger;
        private readonly IWebHostEnvironment _hostEnvironment;

        public PaymentController(ILogger<PaymentController> logger, IWebHostEnvironment hostEnvironment)
        {
            _logger = logger;
            _hostEnvironment = hostEnvironment;
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
            try
            {
                Log.Information("Trying to save Order to Json file");
                string webRootPath = _hostEnvironment.WebRootPath;
                var path = Path.Combine(webRootPath, @"json");
                var order = HttpContext.Session.GetObjectFromJson<Order>("order");
                order.SaveToJson(path);
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Error in saving Order to Json!");
            }
            return Redirect("/confirmation");
        }
    }
}
