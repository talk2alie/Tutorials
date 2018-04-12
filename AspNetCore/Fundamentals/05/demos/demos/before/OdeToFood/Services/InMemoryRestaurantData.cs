using OdeToFood.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OdeToFood.Services
{
    public class InMemoryRestaurantData : IRestaurantData
    {
        private readonly List<Restaurant> _restaurants;

        public InMemoryRestaurantData()
        {
            _restaurants = new List<Restaurant>
            {
                new Restaurant { Id = 1, Name = "Scott's Pizza Place"},
                new Restaurant { Id = 2, Name = "Tersiguels"},
                new Restaurant { Id = 3, Name = "King's Contrivance"}
            };
        }
        
        public IEnumerable<Restaurant> GetAll()
        {
            return _restaurants.OrderBy(r => r.Name);
        }

        public Restaurant Get(int id)
        {
            return _restaurants.SingleOrDefault(restaurant => restaurant.Id == id);
        }

        public void Add(Restaurant restaurant)
        {
            restaurant.Id = _restaurants.Max(entry => entry.Id) + 1;
            _restaurants.Add(restaurant);
        }
    }
}
