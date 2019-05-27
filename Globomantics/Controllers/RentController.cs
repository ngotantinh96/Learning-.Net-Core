using Globomantics.Models;
using Globomantics.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Globomantics.Controllers
{
    public class RentController : Controller
    {
        private ILogger<RentController> logger;
        private IQuoteService quoteService;

        public RentController(IQuoteService quoteService, ILogger<RentController> logger)
        {
            this.logger = logger;
            this.quoteService = quoteService;
        }

        public IActionResult Quote()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Quote(RentalQuote quote)
        {
            quoteService.GenerateRentalQuote(quote);
            return RedirectToAction("Insurance", "Confirmation");
        }
    }
}
