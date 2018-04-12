using Microsoft.AspNetCore.Mvc;
using OdeToFood.Models;
using OdeToFood.Services;
using System.Collections.Generic;

namespace OdeToFood.Controllers
{
    public class HomeController : Controller
    {
        private IRestaurantData _restaurantData;

        public HomeController(IRestaurantData restaurantData)
        {
            _restaurantData = restaurantData;
        }

        public IActionResult Index()
        {
            IEnumerable<Restaurant> model = _restaurantData.GetAll();

            return View(model);
        }

        public IActionResult Details(int id)
        {
            Restaurant model = _restaurantData.Get(id);
            if(model == null)
            {
                return RedirectToAction(nameof(Index));
            }

            return View(model);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(RestaurantEditModel model)
        {
            var restaurant = new Restaurant
            {
                Name = model.Name,
                Cuisine = model.Cuisine
            };

            _restaurantData.Add(restaurant);
            return RedirectToAction(nameof(Details), new { id = restaurant.Id });
        }
    }
}
