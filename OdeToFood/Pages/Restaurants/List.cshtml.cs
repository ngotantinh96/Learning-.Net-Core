using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using OdeToFoo.Data;
using OdeToFood.Core;
using System.Collections.Generic;

namespace OdeToFood.Pages.Restaurants
{
    public class ListModel : PageModel
    {
        private readonly IConfiguration configuration;
        private readonly IRestaurantData restaurantData;
        private readonly ILogger<ListModel> logger;

        public string Message { get; set; }
        public IEnumerable<Restaurant> Restaurants { get; set; }
        [BindProperty(SupportsGet = true)]
        public string SearchTerm { get; set; }

        public ListModel(
            IConfiguration configuration,
            IRestaurantData restaurantData,
            ILogger<ListModel> logger)
        {
            this.configuration = configuration;
            this.restaurantData = restaurantData;
            this.logger = logger;
        }

        public void OnGet()
        {
            logger.LogError("Executing ListModel!");
            Message = configuration["Message"];
            Restaurants = restaurantData.GetRestaurantsByName(SearchTerm);
        }
    }
}