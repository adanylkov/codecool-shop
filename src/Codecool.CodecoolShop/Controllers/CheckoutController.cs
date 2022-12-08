using Microsoft.AspNetCore.Mvc;
using Codecool.CodecoolShop.Models;
using Codecool.CodecoolShop.Helpers;
using Serilog;
using System;
using Codecool.CodecoolShop.Models.ViewModels;

namespace Codecool.CodecoolShop.Controllers
{
    public class CheckoutController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Index(CheckoutViewModel checkout)
        {
            try
            {
                Log.Information("Creating Order object");
                var order = new Order
                {
                    name = checkout.Name,
                    email = checkout.Email,
                    phone = checkout.Phone,
                    billing = new Address
                    {
                        country = checkout.YourCountry,
                        city = checkout.YourCity,
                        zipcode = checkout.YourZipcode,
                        address = checkout.YourAdress
                    },
                    shipping = new Address
                    {
                        country = checkout.ShippingCountry,
                        city = checkout.ShippingCity,
                        zipcode = checkout.ShippingZipcode,
                        address = checkout.ShippingAdress
                    }
                };
                HttpContext.Session.SetObjectAsJson("order", order);
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Error in creating Order object.");
            }
            return Redirect("/payment");
            }
    }
}
