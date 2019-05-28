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

        public AccountController(UserManager<ConfArchUser> userManager)
        {
            this.userManager = userManager;
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
    }
}
