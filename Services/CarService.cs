using Auto.Interfaces;
using Auto.Models;
using System.Collections.Generic;
using System.Linq;

namespace Auto.Services
{
    public class CarService : ICarService
    {
        private static readonly List<Car> cars = new();

        public CarService()
        {
            if (cars.Count == 0)
            {
                cars.Add(new CombustionCar("Skoda", "Superb", 2020, 32000, "Diesel", 7.5));
                cars.Add(new CombustionCar("Audi", "RS7", 2024, 135000, "Petrol", 15.5));
                cars.Add(new ElectricCar("Porsche", "Taycan", 2023, 95000, 75, 450));

                for (int i = 0; i < cars.Count; i++)
                {
                    cars[i].Id = i + 1;
                }
            }
        }

        public List<Car> GetAllCars() => cars;

        public List<Car> GetAvailableCars()
        {
            return cars.Where(c => !c.Sold).ToList();
        }

        public bool SellCar(int id)
        {
            var car = cars.FirstOrDefault(c => c.Id == id);
            if (car != null && !car.Sold)
            {
                car.Sold = true;
                return true;
            }
            return false;
        }

        public int GetSoldCarsCount()
        {
            return cars.Count(c => c.Sold);
        }

        public decimal GetAvailableCarsTotalValue()
        {
            return cars.Where(c => !c.Sold).Sum(c => c.Price);
        }

        public void Reset()
        {
            foreach (var c in cars)
                c.Sold = false;
        }
    }
}