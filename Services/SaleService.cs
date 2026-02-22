using Auto.Interfaces;
using Auto.Models;
using System;
using System.Collections.Generic;

namespace Auto.Services
{
    public class SaleService
    {
        private readonly ISaleRepository _repository;

        public SaleService(ISaleRepository repository)
        {
            _repository = repository;
        }

        public Sell MakeSale(int carId, decimal finalPrice, int? clientId = null, int? employeeId = null)
        {
            var sale = new Sell
            {
                CarId = carId,
                ClientId = clientId,
                EmployeeId = employeeId,
                SaleDate = DateTime.Now,
                FinalPrice = finalPrice,
                PaymentMethod = "Cash"
            };

            return _repository.Add(sale);
        }

        public List<Sell> GetAllSales() => _repository.GetAll();

        public List<Sell> GetSalesByPeriod(DateTime from, DateTime to)
            => _repository.GetByPeriod(from, to);

        public bool DeleteSale(int id) => _repository.Delete(id);

        public void ResetSales() => _repository.Reset();
    }
}