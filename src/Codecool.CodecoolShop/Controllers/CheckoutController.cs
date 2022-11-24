using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Codecool.CodecoolShop.Daos;
using Codecool.CodecoolShop.Daos.Implementations;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Codecool.CodecoolShop.Models;
using Codecool.CodecoolShop.Services;
using Codecool.CodecoolShop.Helpers;

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
            var order = new Order
            {
                name = name,
                email = email,
                phone = phone,
                billing = new Adress
                {
                    country = yourCity,
                    city = yourCity,
                    zipcode = yourZipcode,
                    adress = yourAdress
                },
                shipping = new Adress
                {
                    country = shippingCountry,
                    city = shippingCity,
                    zipcode = shippingZipcode,
                    adress = shippingAdress
                }
            };
            HttpContext.Session.SetObjectAsJson("order", order);
            return Redirect("/payment");
        }
    }
}
