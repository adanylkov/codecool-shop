using Microsoft.AspNetCore.Mvc;
using Codecool.CodecoolShop.Services;
using Serilog;
using Codecool.CodecoolShop.Models.ViewModels;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;

namespace Codecool.CodecoolShop.Controllers;

[AllowAnonymous]
public class SignupController : Controller
{
    private readonly IEmailService _emailService;
    private readonly SignInManager<IdentityUser> _signInManager;
    private readonly UserManager<IdentityUser> _userManager;
    public SignupController(IEmailService emailService, SignInManager<IdentityUser> signInManager, UserManager<IdentityUser> userManager)
    {
        _emailService = emailService;
        _signInManager = signInManager;
        _userManager = userManager;
    }
    [HttpGet]
    public IActionResult Index()
    {
        return View();
    }

    [HttpPost]
    [ActionName("Register")]
    public async Task<IActionResult> RegisterPost(RegisterViewModel registerViewModel)
    {
        if (ModelState.IsValid)
        {
            var user = new IdentityUser { UserName = registerViewModel.Username, Email = registerViewModel.Email };
            var result = await _userManager.CreateAsync(user, registerViewModel.Password);
            if (result.Succeeded)
            {
                Log.Information("Creating User object");
                _emailService.SendRegistrationEmail(registerViewModel.Username, registerViewModel.Email, registerViewModel.Password);
                await _signInManager.SignInAsync(user, isPersistent: false);
                return RedirectPermanent("Index");
            }
            Log.Error("Error in creating User object.");
            foreach (var error in result.Errors)
            {
                Log.Error(error.Description);
                ModelState.AddModelError(string.Empty, error.Description);
            }
        }
        return View("Index");
    }
}
