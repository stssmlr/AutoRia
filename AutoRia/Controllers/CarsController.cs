using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AutoRia.Entities;
using shopL.Data;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace AutoRia.Controllers
{
    public class CarsController : Controller
    {
        private CarsDbContext ctx = new CarsDbContext();
        public CarsController()
        {

        }
        public IActionResult Index()
        {
            var cars = ctx.Cars
                .Include(x => x.Category)
                .Where(x => !x.Archived)
                .ToList();
            return View(cars);
        }

        public IActionResult Archive()
        {
            // .. load data from database ..
            var cars = ctx.Cars
                .Include(x => x.Category) // LEFT JOIN
                .Where(x => x.Archived)
                .ToList();

            return View(cars);
        }

        public IActionResult Delete(int id)
        {
            var car = ctx.Cars.Find(id);

            if (car == null) return NotFound();

            ctx.Cars.Remove(car);
            ctx.SaveChanges();

            return RedirectToAction("Archive");
        }

        public IActionResult ArchiveItem(int id)
        {
            var car = ctx.Cars.Find(id);

            if (car == null) return NotFound();

            car.Archived = true;
            ctx.SaveChanges();

            return RedirectToAction("Index");
        }

        public IActionResult RestoreItem(int id)
        {
            var car = ctx.Cars.Find(id);

            if (car == null) return NotFound();

            car.Archived = false;
            ctx.SaveChanges();

            return RedirectToAction("Archive");
        }

        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.Categories = new SelectList(ctx.Category.ToList(), "Id", "Name");
            return View();
        }

        [HttpPost]
        public IActionResult Create(Car car)
        {
            // TODO: add data validation

            ctx.Cars.Add(car);
            ctx.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}
