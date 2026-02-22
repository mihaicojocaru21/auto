using Auto.Models;
using System.Collections.Generic;
using System.Linq;

namespace Auto.Services
{
    public static class SaleService
    {
        private static List<Sell> sales = new List<Sell>();
        private static int nextSaleId = 1;
        
        public static Sell MakeSale(int carId, decimal finalPrice, 
            int? clientId = null, int? employeeId = null)
        {
            var sale = new Sell
            {
                Id = nextSaleId++,
                CarId = carId,
                ClientId = clientId,
                EmployeeId = employeeId,
                SaleDate = DateTime.Now,
                FinalPrice = finalPrice,
                PaymentMethod = "Cash"
            };
            
            sales.Add(sale);
            return sale;
        }
        
        public static List<Sell> GetAllSales()
        {
            return sales;
        }
        
        public static List<Sell> GetSalesByPeriod(DateTime from, DateTime to)
        {
            return sales.Where(v => v.SaleDate >= from && v.SaleDate <= to).ToList();
        }
        
        public static decimal GetTotalRevenue()
        {
            return sales.Sum(v => v.FinalPrice);
        }
        
        public static string GetBestSellingModel()
        {
            if (!sales.Any()) return "No sales yet";
            return "Analysis in progress...";
        }
        
        public static bool DeleteSale(int id)
        {
            var sale = sales.FirstOrDefault(v => v.Id == id);
            if (sale != null)
            {
                sales.Remove(sale);
                return true;
            }
            return false;
        }
        
        public static void ResetSales()
        {
            sales.Clear();
            nextSaleId = 1;
        }
    }
}