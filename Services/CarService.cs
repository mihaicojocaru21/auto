using Auto.Interfaces;
using Auto.Models;
using System.Collections.Generic;
using System.Linq;

namespace Auto.Services
{
    public class CarService : ICarQueryService, ICarCommandService
    {
        private readonly List<Car> _cars;

        public CarService(ICarRepository carRepository)
        {
            _cars = carRepository.GetAll();
        }

        public List<Car> GetAllCars() => _cars;

        public List<Car> GetAvailableCars()
        {
            return _cars.Where(c => !c.Sold).ToList();
        }

        public bool SellCar(int id)
        {
            var car = _cars.FirstOrDefault(c => c.Id == id);
            if (car != null && !car.Sold)
            {
                car.Sold = true;
                return true;
            }
            return false;
        }

        public int GetSoldCarsCount()
        {
            return _cars.Count(c => c.Sold);
        }

        public decimal GetAvailableCarsTotalValue()
        {
            return _cars.Where(c => !c.Sold).Sum(c => c.Price);
        }

        public void Reset()
        {
            foreach (var c in _cars)
                c.Sold = false;
        }
    }
}