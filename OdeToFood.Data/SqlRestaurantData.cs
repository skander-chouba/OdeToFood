using OdeToFood.Core;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;

namespace OdeToFood.Data
{
    public class SqlRestaurantData : IRestaurantData
    {
        private readonly OdeToFoodDbContext context;

        public SqlRestaurantData(OdeToFoodDbContext context)
        {
            this.context = context;
        }
        public int Commit()
        {
            return context.SaveChanges();
        }

        public Restaurant Create(Restaurant restaurant)
        {
            context.Add(restaurant);
            return restaurant;
        }

        public Restaurant Delete(int id)
        {
            var restaurant = GetById(id);
            if (restaurant != null)
            {
                context.Remove(restaurant);
            }
            return restaurant;
        }

        public IEnumerable<Restaurant> GetAllByName(string name)
        {
            var query = from r in context.Restaurants
                        where r.Name.StartsWith(name) || string.IsNullOrEmpty(name)
                        orderby r.Name
                        select r;
            return query;
        }

        public Restaurant GetById(int id)
        {
            return context.Restaurants.Find(id);
        }

        public int GetCountOfRestaurants()
        {
            return context.Restaurants.Count();
        }

        public Restaurant Update(Restaurant updatedRestaurant)
        {
            var entity = context.Restaurants.Attach(updatedRestaurant);
            entity.State = EntityState.Modified;
            return updatedRestaurant;
        }
    }
}
