using AuthoringTagHelpers.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Diagnostics;

namespace AuthoringTagHelpers.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            WebsiteContext webContext = new WebsiteContext
            {
                Version = new Version(1, 3),
                CopyrightYear = 1638,
                Approved = true,
                TagsToShow = 131
            };

            return View(webContext);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
