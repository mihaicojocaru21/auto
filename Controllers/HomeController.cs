using Microsoft.AspNetCore.Mvc;
using Auto.Interfaces;
using Auto.Services;
using System.Linq;

namespace Auto.Controllers
{
    public class HomeController : Controller
    {
        private readonly ICarService _carService;
        
        public HomeController()
        {
            _carService = ServiceFactory.GetCarService();
        }
        
        public IActionResult Index()
        {
            var cars = _carService.GetAllCars();

            ViewBag.TotalCars = cars.Count;
            ViewBag.SoldCars = cars.Count(m => m.Sold);
            ViewBag.TotalValue = cars.Where(m => !m.Sold).Sum(m => m.Price);

            return View(cars);
        }

        public IActionResult Sell(int id)
        {
            var success = _carService.SellCar(id);
            
            if (success)
            {
                var car = _carService.GetAllCars().FirstOrDefault(m => m.Id == id);
                TempData["Message"] = $"Car {car.GetInfo()} was sold!";
            }
            else
            {
                TempData["Error"] = "Car doesn't exist or is already sold!";
            }
            
            return RedirectToAction("Index");
        }

        public IActionResult Reset()
        {
            _carService.Reset();
            TempData["Message"] = "Reset completed!";
            return RedirectToAction("Index");
        }
    }
}