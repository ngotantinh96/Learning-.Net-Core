using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;
using OdeToFoo.Data;
using OdeToFood.Core;
using System.Collections.Generic;

namespace OdeToFood.Pages.Restaurants
{
    public class ListModel : PageModel
    {
        private readonly IConfiguration configuration;
        private readonly IRestaurantData restaurantData;

        public string Message { get; set; }
        public IEnumerable<Restaurant> Restaurants { get; set; }

        public ListModel(
            IConfiguration configuration,
            IRestaurantData restaurantData)
        {
            this.configuration = configuration;
            this.restaurantData = restaurantData;
        }

        public void OnGet(string searchTerm)
        {
            Message = configuration["Message"];
            Restaurants = restaurantData.GetRestaurantsByName(searchTerm);
        }
    }
}