using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Web;
using Microsoft.AspNetCore.Http;
using OdeToFood.Models;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace OdeToFood.Controllers
{
    public class ImagesController : Controller
    {
        private ImageStore _store = new ImageStore();

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> Upload(IFormFile image)
        {
            if (image != null)
            {
                string imageId = await _store.SaveImageAsync(image.OpenReadStream());
                return RedirectToAction(nameof(Show), new { id = imageId });
            }

            return View(nameof(Index));
        }

        public IActionResult Show(string id)
        {
            var model = new ShowModel { Uri = _store.UriFor(id) };

            return View(model);
        }
    }
}