using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using TennisBookings.Web.Configuration;
using TennisBookings.Web.Services;
using TennisBookings.Web.ViewModels;

namespace TennisBookings.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly IWeatherForecaster weatherForecaster;

        public HomeController(IWeatherForecaster weatherForecaster)
        {
            this.weatherForecaster = weatherForecaster;
        }
        [Route("")]
        public IActionResult Index()
        {
            var viewModel = new HomeViewModel
            {
                WeatherDescription = weatherForecaster.GetCurrentWeatherAsync().Result.Description
            };

            return View(viewModel);
        }
    }
}