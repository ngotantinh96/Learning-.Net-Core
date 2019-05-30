using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using WebAppTagHelper.Models;

namespace WebAppTagHelper.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public IActionResult ModelTest()
        {
            var model = new ModelAddress()
            {
                FirstName = "Peter",
                LastName = "Kellner"
            };
            return View("ModelTest", model);
        }
    }
}
