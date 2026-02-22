using Auto.Models;

namespace Auto.Interfaces
{
    public class HybridCar : Car
    {
        public int BatteryCapacity { get; set; }
        public string FuelType { get; set; } = string.Empty;

        
        public HybridCar(string brand, string model, int year, decimal price,
            int batteryCapacity, string fuelType)
            : base(brand, model, year, price)
        {
            BatteryCapacity = batteryCapacity;
            FuelType = fuelType;
        }
        
        public override string Description()
        {
            return base.Description() + 
                   $" | Hybrid: {BatteryCapacity}kWh + {FuelType}";
        }
    }
}