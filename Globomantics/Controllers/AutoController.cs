using Globomantics.Models;
using Globomantics.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Globomantics.Controllers
{
    public class AutoController : Controller
    {
        private ILogger<AutoController> logger;
        private IQuoteService quoteService;

        public AutoController(IQuoteService quoteService, ILogger<AutoController> logger)
        {
            this.logger = logger;
            this.quoteService = quoteService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Quote()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Quote(AutoQuote quote)
        {
            quoteService.GenerateAutoQuote(quote);
            return RedirectToAction("Confirmation", "Insurance");
        }

        [HttpGet]
        public IActionResult Person()
        {
            return View();
        }
    }
}
