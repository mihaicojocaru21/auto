using Auto.Interfaces;
using Auto.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Auto.Repositories
{
    public class InMemorySaleRepository : ISaleRepository
    {
        private readonly List<Sell> _sales = new();
        private int _nextSaleId = 1;

        public Sell Add(Sell sale)
        {
            sale.Id = _nextSaleId++;
            _sales.Add(sale);
            return sale;
        }

        public List<Sell> GetAll() => _sales;

        public List<Sell> GetByPeriod(DateTime from, DateTime to)
        {
            return _sales.Where(v => v.SaleDate >= from && v.SaleDate <= to).ToList();
        }

        public bool Delete(int id)
        {
            var sale = _sales.FirstOrDefault(v => v.Id == id);
            if (sale != null)
            {
                _sales.Remove(sale);
                return true;
            }
            return false;
        }

        public void Reset()
        {
            _sales.Clear();
            _nextSaleId = 1;
        }
    }
}