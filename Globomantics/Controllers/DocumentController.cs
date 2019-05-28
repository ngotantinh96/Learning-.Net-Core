using Globomantics.ActionResults;
using Globomantics.Services;
using Microsoft.AspNetCore.Mvc;

namespace Globomantics.Controllers
{
    public class DocumentController : Controller
    {
        private IRateService rateService;

        public DocumentController(IRateService rateService)
        {
            this.rateService = rateService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult GetCDRates()
        {
            var cdRates = rateService.GetCDRates();

            return new CsvResult(cdRates, "CD Rates");
        }

        public IActionResult GetMortgageRates()
        {
            var mortRates = rateService.GetMortgageRates();

            return new CsvResult(mortRates, "Mortgage Rates");
        }

        public IActionResult GetCreditCardRates()
        {
            var creditRates = rateService.GetCreditCardRates();

            return new CsvResult(creditRates, "Credit Rates");
        }
    }
}
