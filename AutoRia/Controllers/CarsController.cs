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

        // -+-+-+-+-+-+-+-+-+-+-+-+- INDEX -+-+-+-+-+-+-+-+-+-+-+-+-
        public IActionResult Index()
        {
            var cars = ctx.Cars
                .Include(x => x.Category)
                .Include(x => x.FuelType)
                .Where(x => !x.Archived)
                .ToList();
            return View(cars);
        }

        // -+-+-+-+-+-+-+-+-+-+-+-+- ARCHIEVE -+-+-+-+-+-+-+-+-+-+-+-+-
        public IActionResult Archive()
        {
            // .. load data from database ..
            var cars = ctx.Cars
                .Include(x => x.Category) // LEFT JOIN
                .Where(x => x.Archived)
                .ToList();

            return View(cars);
        }

        public IActionResult ArchiveItem(int id)
        {
            var car = ctx.Cars.Find(id);

            if (car == null) return NotFound();

            car.Archived = true;
            ctx.SaveChanges();

            return RedirectToAction("Index");
        }

        // -+-+-+-+-+-+-+-+-+-+-+-+- DELETE -+-+-+-+-+-+-+-+-+-+-+-+-
        public IActionResult Delete(int id)
        {
            var car = ctx.Cars.Find(id);

            if (car == null) return NotFound();

            ctx.Cars.Remove(car);
            ctx.SaveChanges();

            return RedirectToAction("Archive");
        }

        // -+-+-+-+-+-+-+-+-+-+-+-+- RESTORE FROM ARCHIEVE -+-+-+-+-+-+-+-+-+-+-+-+-
        public IActionResult RestoreItem(int id)
        {
            var car = ctx.Cars.Find(id);

            if (car == null) return NotFound();

            car.Archived = false;
            ctx.SaveChanges();

            return RedirectToAction("Archive");
        }

        // -+-+-+-+-+-+-+-+-+-+-+-+- CREATE -+-+-+-+-+-+-+-+-+-+-+-+-
        [HttpGet]
        public IActionResult Create()
        {
            LoadTypesOfFuel();
            LoadCategories();
            ViewBag.CreateMode = true;
            return View("Upsert");
        }

        [HttpPost]
        public IActionResult Create(Car car)
        {
            // TODO: add data validation
            if (!ModelState.IsValid)
            {
                ViewBag.CreateMode = true;
                LoadTypesOfFuel();
                LoadCategories();
                return View("Upsert", car);
            }

            ctx.Cars.Add(car);
            ctx.SaveChanges();

            return RedirectToAction("Index");
        }

        // -+-+-+-+-+-+-+-+-+-+-+-+- EDIT -+-+-+-+-+-+-+-+-+-+-+-+-
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var car = ctx.Cars.Find(id);

            if (car == null) return NotFound();

            LoadTypesOfFuel();
            LoadCategories();
            ViewBag.CreateMode = false;
            return View("Upsert", car);
        }

        [HttpPost]
        public IActionResult Edit(Car car)
        {
            // TODO: add data validation
            if (!ModelState.IsValid)
            {
                ViewBag.CreateMode = true;
                LoadTypesOfFuel();
                LoadCategories();
                return View("Upsert", car);
            }

            ctx.Cars.Update(car);
            ctx.SaveChanges();

            return RedirectToAction("Index");
        }

        // -+-+-+-+-+-+-+-+-+-+-+-+- FUNCTIONS -+-+-+-+-+-+-+-+-+-+-+-+-
        private void LoadCategories()
        {
            // ViewBag.PropertyName = value;
            ViewBag.Categories = new SelectList(ctx.Category.ToList(), "Id", "Name");
        }
        private void LoadTypesOfFuel()
        {
            // ViewBag.PropertyName = value;
            ViewBag.FuelTypes = new SelectList(ctx.FuelType.ToList(), "Id", "Name");
        }
    }
}
