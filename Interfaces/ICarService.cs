using Auto.Models;
using System.Collections.Generic;

namespace Auto.Interfaces
{
    public interface ICarService
    {
        List<Car> GetAllCars();
        List<Car> GetAvailableCars();
        bool SellCar(int id);
        int GetSoldCarsCount();
        decimal GetAvailableCarsTotalValue();
        void Reset();
    }
}