using Codecool.CodecoolShop.Models.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Serilog;
using System.Threading.Tasks;

namespace Codecool.CodecoolShop.Controllers;

[AllowAnonymous]
public class LoginController : Controller
{
    private UserManager<IdentityUser> _userManager;
    private SignInManager<IdentityUser> _signInManager;

    public LoginController(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager)
    {
        _userManager = userManager;
        _signInManager = signInManager;
    }
    public IActionResult Index()
    {
        return View();
    }
    public async Task<IActionResult> OnPostAsync(LoginViewModel viewModel, string returnUrl = null)
        {
            returnUrl ??= Url.Content("~/");
 
        
            if (ModelState.IsValid)
            {
                // This doesn't count login failures towards account lockout
                // To enable password failures to trigger account lockout, set lockoutOnFailure: true
                var result = await _signInManager.PasswordSignInAsync(viewModel.Email, viewModel.Password, isPersistent: true, lockoutOnFailure: false);
                if (result.Succeeded)
                {
                    Log.Information("User logged in.");
                    return LocalRedirect(returnUrl);
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Invalid login attempt.");
                return View("Index");
                }
            }
 
            // If we got this far, something failed, redisplay form
        return View("Index");
        }
}
