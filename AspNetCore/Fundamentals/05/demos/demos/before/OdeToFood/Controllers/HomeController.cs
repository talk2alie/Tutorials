using Microsoft.AspNetCore.Mvc;
using OdeToFood.Models;
using OdeToFood.Repositories;
using OdeToFood.Services;
using System.Collections.Generic;

namespace OdeToFood.Controllers
{
    public class HomeController : Controller
    {
        private IRestaurantRepository _repository;

        public HomeController(IRestaurantRepository repository)
        {
            _repository = repository;
        }

        public IActionResult Index()
        {
            IEnumerable<Restaurant> model = _repository.GetAll();

            return View(model);
        }

        public IActionResult Details(int id)
        {
            Restaurant model = _repository.Get(id);
            if (model == null)
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
        [ValidateAntiForgeryToken]
        public IActionResult Create(RestaurantEditModel model)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            var restaurant = new Restaurant
            {
                Name = model.Name,
                Cuisine = model.Cuisine
            };

            _repository.Add(restaurant);
            _repository.CommitChanges();
            return RedirectToAction(nameof(Details), new { id = restaurant.Id });
        }
    }
}
