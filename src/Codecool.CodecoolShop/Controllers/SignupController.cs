using Microsoft.AspNetCore.Mvc;
using Codecool.CodecoolShop.Models;
using Codecool.CodecoolShop.Helpers;
using Serilog;
using System;

namespace Codecool.CodecoolShop.Controllers
{
    public class SignupController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Index(string name, string email, string password)
        {
            try
            {
                Log.Information("Creating User object");
                var user = new User
                {
                    Name = name,
                    Email = email,
                    Password =password
                };
                //HttpContext.Session.SetObjectAsJson("order", order);
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Error in creating User object.");
            }
            return Redirect("/payment");
            }
    }
}
