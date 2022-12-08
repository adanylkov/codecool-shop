using Microsoft.AspNetCore.Mvc;
using Codecool.CodecoolShop.Services;
using Serilog;
using System;
using Codecool.CodecoolShop.Domain;

namespace Codecool.CodecoolShop.Controllers
{
    public class SignupController : Controller
    {
        private readonly IEmailService _emailService;
        public SignupController(IEmailService emailService)
        {
            _emailService = emailService;
        }
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
                
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Error in creating User object.");
            }
            _emailService.SendRegistrationEmail(name,email,password);
            return Redirect("/product");
            }
    }
}
