using Auto.Models;
using System.Collections.Generic;

namespace Auto.Interfaces
{
    public interface ICarRepository
    {
        List<Car> GetAll();
    }
}