using Auto.Models;

namespace Auto.Interfaces
{
    public class CombustionCar : Car
    {
        public string FuelType { get; set; }
        public double MPG { get; set; }
        
        public CombustionCar(string brand, string model, int year, decimal price,
            string fuelType, double mpg)
            : base(brand, model, year, price)
        {
            FuelType = fuelType;
            MPG = mpg;
        }
        
        public override string Description()
        {
            return base.Description() + $" | Fuel: {FuelType}, MPG: {MPG}L/100km";
        }
    }
}