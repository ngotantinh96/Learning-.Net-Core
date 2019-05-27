using Globomantics.Core.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Globomantics.Controllers
{
    public class InsuranceController : Controller
    {
        private ILogger<InsuranceController> logger;

        public InsuranceController(ILogger<InsuranceController> logger)
        {
            this.logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(Contact contact)
        {
            return RedirectToAction("Confirmation");
        }

        public IActionResult Confirmation()
        {
            return View();
        }
    }
}
