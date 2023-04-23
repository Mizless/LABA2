using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using LAB2.Models;

namespace Lab_2.Controllers
{
    public class HomeController : Controller
    {
        private static List<DatabaseModel> database = new List<DatabaseModel>();

        // Метод для внутреннего использования
        private List<DatabaseModel> GetDatabase()
        {
            return database;
        }

        // Метод для внешнего использования
        [HttpGet]
        public IActionResult GetDatabase(bool isInternal = false)
        {
            if (isInternal)
            {
                return View("Index", GetDatabase());
            }
            else
            {
                return Json(GetDatabase());
            }
        }

        public IActionResult Index()
        {
            return GetDatabase(true);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(DatabaseModel model)
        {
            model.ID = database.Count + 1;
            database.Add(model);

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var model = database.FirstOrDefault(m => m.ID == id);

            if (model != null)
            {
                return View(model);
            }

            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Delete(DatabaseModel model)
        {
            var modelToDelete = database.FirstOrDefault(m => m.ID == model.ID);

            if (modelToDelete != null)
            {
                database.Remove(modelToDelete);
            }

            return RedirectToAction("Index");
        }
    }
}
