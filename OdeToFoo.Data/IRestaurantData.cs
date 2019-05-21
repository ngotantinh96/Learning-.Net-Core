using OdeToFood.Core;
using System.Collections.Generic;

namespace OdeToFoo.Data
{
    public interface IRestaurantData
    {
        IEnumerable<Restaurant> GetRestaurantsByName(string name);
        Restaurant GetById(int id);
        Restaurant Update(Restaurant restaurant);
        Restaurant Add(Restaurant restaurant);
        Restaurant Delete(int id);
        int Commit();
    }
}
