using Auto.Models;
using System;
using System.Collections.Generic;

namespace Auto.Interfaces
{
    public interface ISaleRepository
    {
        Sell Add(Sell sale);
        List<Sell> GetAll();
        List<Sell> GetByPeriod(DateTime from, DateTime to);
        bool Delete(int id);
        void Reset();
    }
}