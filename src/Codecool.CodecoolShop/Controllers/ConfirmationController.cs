using Codecool.CodecoolShop.Helpers;
using Codecool.CodecoolShop.Models;
using Microsoft.AspNetCore.Mvc;

namespace Codecool.CodecoolShop.Controllers
{
    public class ConfirmationController : Controller
    {
        public IActionResult Index()
        {
            var order = HttpContext.Session.GetObjectFromJson<Order>("order");
            return View(order);
        }
    }
}
