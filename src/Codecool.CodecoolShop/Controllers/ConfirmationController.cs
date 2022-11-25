using Codecool.CodecoolShop.Daos.Implementations;
using Codecool.CodecoolShop.Helpers;
using Codecool.CodecoolShop.Models;
using Microsoft.AspNetCore.Mvc;
using System.Text;

namespace Codecool.CodecoolShop.Controllers
{
    public class ConfirmationController : Controller
    {
        public IActionResult Index()
        {
            var order = HttpContext.Session.GetObjectFromJson<Order>("order");
            if (order is not null)
            {
                SendEmailConfirmation();
            }
            return View(order);
        }

        private void SendEmailConfirmation()
        {
            var order = HttpContext.Session.GetObjectFromJson<Order>("order");
            var cart = HttpContext.Session.GetObjectFromJson<Cart>("cart");
            var productDao = ProductDaoMemory.GetInstance();
            var emailBody = new StringBuilder();
            emailBody.AppendLine($"Hello, {order.name}");
            emailBody.AppendLine("Order details:");
            var total = 0M;
            foreach (var item in cart.GetAll())
            {
                var product = productDao.Get(item.Key);
                total += product.DefaultPrice * item.Value;
                emailBody.AppendLine($"{product.Name} x{item.Value} = {product.DefaultPrice * item.Value}$");
            }
            emailBody.AppendLine(new string('-', 20));
            emailBody.AppendLine($"Total: {total}$");

            var email = new Email(order.email, "Your order confirmation", emailBody.ToString());
            email.Send();
        }
    }
}
