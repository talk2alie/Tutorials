using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OdeToFood.Models;

namespace OdeToFood.Repositories
{
    public class RestaurantRespository : IRestaurantRepository
    {
        private OdeToFoodDbContext _context;

        public RestaurantRespository(OdeToFoodDbContext context)
        {
            _context = context;
        }

        public void Add(Restaurant restaurant)
        {
            _context.Add(restaurant);
        }

        public Restaurant Get(int id)
        {
            return _context.Restaurants.Find(id);
        }

        public IEnumerable<Restaurant> GetAll()
        {
            return _context.Restaurants.ToList();
        }

        public void CommitChanges()
        {
            _context.SaveChanges();
        }
    }
}
