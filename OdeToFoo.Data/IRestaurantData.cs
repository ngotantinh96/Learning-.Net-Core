using OdeToFood.Core;
using System.Collections.Generic;
using System.Linq;

namespace OdeToFoo.Data
{
    public interface IRestaurantData
    {
        IEnumerable<Restaurant> GetRestaurantsByName(string name);

    }

    public class InMemoryRestaurantData : IRestaurantData
    {
        List<Restaurant> restaurants;

        public InMemoryRestaurantData()
        {
            restaurants = new List<Restaurant>()
            {
                new Restaurant { Id = 1, Name = "Scott's Pizza", Location = "Maryland", Cuisine = CuisineType.Italian},
                new Restaurant { Id = 2, Name = "Cinnamon Club", Location = "London", Cuisine = CuisineType.Indian},
                new Restaurant { Id = 3, Name = "La costa", Location = "California", Cuisine = CuisineType.Mexican}
            };
        }

        public IEnumerable<Restaurant> GetRestaurantsByName(string name = "")
        {
            return restaurants.Where(r => string.IsNullOrEmpty(name) || r.Name.StartsWith(name))
                .OrderBy(r => r.Name);
        }
    }
}
