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
    }
}
