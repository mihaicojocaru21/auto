using Auto.Interfaces;

namespace Auto.Models
{
    public class Car : ICar
    {
        public int Id { get; set; }
        public string Brand { get; set; } = string.Empty;
        public string Model { get; set; } = string.Empty;
        public int Year { get; set; }
        public decimal Price { get; set; }
        public bool Sold { get; set; }

        public Car() { }

        public Car(string brand, string model, int year, decimal price)
        {
            Brand = brand; 
            Model = model;
            Year = year;
            Price = price;
            Sold = false;
        }

        public virtual string Description()
        {
            return $"{Brand} {Model} ({Year}) - {Price} EUR";
        }

        public string GetInfo()
        {
            return $"{Brand} {Model} ({Year})";
        }

        public decimal GetPrice()
        {
            return Price;
        }
    }
}