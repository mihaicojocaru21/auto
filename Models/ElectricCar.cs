using Auto.Models;

namespace Auto.Interfaces
{
    public class ElectricCar : Car 
    {
        public int Battery { get; set; }
        public int Range { get; set; }
        
        public ElectricCar(string brand, string model, int year, decimal price,
            int battery, int range)
            : base(brand, model, year, price)
        {
            Battery = battery;
            Range = range;
        }
        
        public override string Description()
        {
            return base.Description() + $" | Battery: {Battery}kWh, Range: {Range}km";
        }
    }
}