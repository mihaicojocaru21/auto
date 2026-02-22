using System;

namespace Auto.Models
{
    public class Sell
    {
        public int Id { get; set; }
        public int CarId { get; set; }
        public int? ClientId { get; set; }
        public int? EmployeeId { get; set; }
        public DateTime SaleDate { get; set; }
        public decimal FinalPrice { get; set; }
        public string PaymentMethod { get; set; } = "Cash";
        
        public Sell()
        {
            SaleDate = DateTime.Now;
        }
        
        public void ApplyDiscount(decimal discountPercent)
        {
            if (discountPercent > 0 && discountPercent <= 100)
            {
                FinalPrice -= FinalPrice * (discountPercent / 100);
            }
        }
        
        public string GetSaleInfo()
        {
            return $"Sale #{Id} | Date: {SaleDate:dd.MM.yyyy HH:mm} | Amount: {FinalPrice:C}";
        }
    }
}