using Microsoft.AspNetCore.Mvc;
using OdeToFood.Models;
using OdeToFood.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OdeToFood.Controllers
{
    public class DocumentsController : Controller
    {
        public DocumentsController(CourseStore store)
        {
            _store = store;
        }

        public ActionResult Index()
        {
            var model = _store.GetAllCourses().ToList();
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Insert()
        {
            var data = new SampleData().GetCourses();
            await _store.InsertCourses(data);

            return RedirectToAction(nameof(Index));
        }

        CourseStore _store;
    }
}
