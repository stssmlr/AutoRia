using Microsoft.AspNetCore.Mvc;

using shopL.Data;

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
            var cars = ctx.Cars.ToList();
            return View(cars);
        }
    }
}
