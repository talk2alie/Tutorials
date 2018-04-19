using OdeToFood.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OdeToFood.Repositories
{
    public interface IRestaurantRepository
    {
        void Add(Restaurant restaurant);

        Restaurant Get(int id);

        IEnumerable<Restaurant> GetAll();

        void CommitChanges();
    }
}
