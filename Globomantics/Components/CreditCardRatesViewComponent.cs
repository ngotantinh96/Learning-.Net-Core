using Globomantics.Models;
using Globomantics.Services;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Globomantics.Components
{
    public class CreditCardRatesViewComponent : ViewComponent
    {
        private readonly IRateService rateService;

        public CreditCardRatesViewComponent(IRateService rateService)
        {
            this.rateService = rateService;
        }

        public async Task<IViewComponentResult> InvokeAsync(
            string title, string subtitle)
        {
            var ratesVM = new CreditCardWidgetVM()
            {
                Rates = rateService.GetCreditCardRates(),
                WidgetTitle = title,
                WidgetSubTitle = subtitle
            };

            return View(ratesVM);
        }
    }
}
