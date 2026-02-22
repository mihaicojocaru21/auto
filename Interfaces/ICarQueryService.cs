using Auto.Models;
using System.Collections.Generic;

namespace Auto.Interfaces
{
    public interface ICarQueryService
    {
        List<Car> GetAllCars();
        List<Car> GetAvailableCars();
        int GetSoldCarsCount();
        decimal GetAvailableCarsTotalValue();
    }
}