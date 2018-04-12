using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OdeToFood.Models
{
    public class RestaurantEditModel
    {
        public string Name { get; set; }

        public CuisineType Cuisine { get; set; }
    }
}
