using AspNetSecurityNoSecurity.Data;
using AspNetSecurityNoSecurity.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace AspNetSecurityNoSecurity.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<ConfArchUser> userManager;
        private readonly SignInManager<ConfArchUser> signInManager;

        public AccountController(UserManager<ConfArchUser> userManager, SignInManager<ConfArchUser> signInManager)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            if (!ModelState.IsValid)
                return View("Error");

            var result = await userManager.CreateAsync(
                new ConfArchUser { UserName = model.Email, Email = model.Email }, model.Password);

            if (result.Succeeded)
                return View("RegistrationConfirmation");

            foreach (var error in result.Errors)
            {
                ModelState.AddModelError("error", error.Description);
            }
            return View(model);
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginViewModel model, string returnUrl = null)
        {
            ViewData["ReturnUrl"] = returnUrl;
            if (ModelState.IsValid)
            {
                var result = await signInManager
                    .PasswordSignInAsync(model.Email, model.Password, model.RememberMe, lockoutOnFailure: false);
                if (result.Succeeded)
                    return RedirectToLocal(returnUrl);
                if (result.RequiresTwoFactor)
                {

                }
                if (result.IsLockedOut)
                {
                    return View("Lockout");
                }
                ModelState.AddModelError(string.Empty, "Invalid login attempt.");

                return View(model);
            }
            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> LogOff()
        {
            await signInManager.SignOutAsync();
            return View("LoggedOut");
        }

        private IActionResult RedirectToLocal(string returnUrl)
        {
            if (Url.IsLocalUrl(returnUrl))
            {
                return Redirect(returnUrl);
            }

            return RedirectToAction("Index", "Conference");
        }
    }
}
