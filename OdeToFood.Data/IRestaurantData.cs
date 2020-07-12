using OdeToFood.Core;

using System.Collections.Generic;

namespace OdeToFood.Data
{
    public interface IRestaurantData
    {
        IEnumerable<Restaurant> GetAllByName(string name);
        Restaurant GetById(int id);
        Restaurant Update(Restaurant updatedRestaurant);    
        Restaurant Create(Restaurant restaurant);
        Restaurant Delete(int id);
        int Commit();
        int GetCountOfRestaurants();
    }

}
