using Globomantics.Models;
using Globomantics.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Globomantics.Controllers
{
    public class PropertyController : Controller
    {
        private ILogger<PropertyController> logger;
        private IQuoteService quoteService;

        public PropertyController(IQuoteService quoteService, ILogger<PropertyController> logger)
        {
            this.logger = logger;
            this.quoteService = quoteService;
        }

        public IActionResult Quote()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Quote(PropertyQuote quote)
        {
            quoteService.GeneratePropertyQuote(quote);
            return RedirectToAction("Insurance", "Confirmation");
        }
    }
}
