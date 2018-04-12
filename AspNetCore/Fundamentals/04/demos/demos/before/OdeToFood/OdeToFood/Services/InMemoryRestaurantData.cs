using System.Collections.Generic;
using System.Linq;
using OdeToFood.Models;

namespace OdeToFood.Services
{
    public class InMemoryRestaurantData : IRestaurantData
    {
        private readonly List<Restaurant> _restaurants;

        public InMemoryRestaurantData()
        {
            _restaurants = new List<Restaurant> 
            {
                new Restaurant {Id = 1, Name = "Scott's Pizza Place"},
                new Restaurant {Id = 2, Name = "Tersiguels"},
                new Restaurant {Id = 3, Name = "King's Contrivance"}
            };
        }

        public IEnumerable<Restaurant> GetAll()
        {
            return _restaurants.OrderBy(restaurant => restaurant.Name);
        }

        public Restaurant Get(int id)
        {
            return _restaurants.SingleOrDefault(resturant => resturant.Id == id);
        }
    }
}