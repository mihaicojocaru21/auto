using Microsoft.AspNetCore.Mvc;
using Auto.Interfaces;
using System.Linq;

namespace Auto.Controllers
{
    public class HomeController : Controller
    {
        private readonly ICarQueryService _carQueryService;
        private readonly ICarCommandService _carCommandService;
        
        public HomeController(ICarQueryService carQueryService, ICarCommandService carCommandService)
        {
            _carQueryService = carQueryService;
            _carCommandService = carCommandService;
        }
        
        public IActionResult Index()
        {
            var cars = _carQueryService.GetAllCars();

            ViewBag.TotalCars = cars.Count;
            ViewBag.SoldCars = cars.Count(m => m.Sold);
            ViewBag.TotalValue = cars.Where(m => !m.Sold).Sum(m => m.Price);

            return View(cars);
        }

        public IActionResult Sell(int id)
        {
            var success = _carCommandService.SellCar(id);
            
            if (success)
            {
                var car = _carQueryService.GetAllCars().FirstOrDefault(m => m.Id == id);
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
            _carCommandService.Reset();
            TempData["Message"] = "Reset completed!";
            return RedirectToAction("Index");
        }
    }
}