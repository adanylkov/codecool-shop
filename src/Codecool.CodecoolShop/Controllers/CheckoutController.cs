using Microsoft.AspNetCore.Mvc;
using Codecool.CodecoolShop.Models;
using Codecool.CodecoolShop.Helpers;
using Serilog;
using System;

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
        public IActionResult Index(string name, string email, string phone, string yourCountry, string yourCity, string yourZipcode, string yourAdress, string shippingCountry, string shippingCity, string shippingZipcode, string shippingAdress)
        {
            try
            {
                Log.Information("Creating Order object");
                var order = new Order
                {
                    name = name,
                    email = email,
                    phone = phone,
                    billing = new Address
                    {
                        country = yourCountry,
                        city = yourCity,
                        zipcode = yourZipcode,
                        address = yourAdress
                    },
                    shipping = new Address
                    {
                        country = shippingCountry,
                        city = shippingCity,
                        zipcode = shippingZipcode,
                        address = shippingAdress
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
