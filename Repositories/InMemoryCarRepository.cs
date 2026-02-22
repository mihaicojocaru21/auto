using Auto.Interfaces;
using Auto.Models;
using System.Collections.Generic;

namespace Auto.Repositories
{
    public class InMemoryCarRepository : ICarRepository
    {
        private readonly List<Car> _cars = new();

        public InMemoryCarRepository()
        {
            if (_cars.Count == 0)
            {
                _cars.Add(new CombustionCar("Skoda", "Superb", 2020, 32000, "Diesel", 7.5));
                _cars.Add(new CombustionCar("Audi", "RS7", 2024, 135000, "Petrol", 15.5));
                _cars.Add(new ElectricCar("Porsche", "Taycan", 2023, 95000, 75, 450));

                for (int i = 0; i < _cars.Count; i++)
                {
                    _cars[i].Id = i + 1;
                }
            }
        }

        public List<Car> GetAll() => _cars;
    }
}