using Auto.Interfaces;
using System.Linq;

namespace Auto.Services
{
    public class SaleAnalyticsService
    {
        private readonly ISaleRepository _repository;

        public SaleAnalyticsService(ISaleRepository repository)
        {
            _repository = repository;
        }

        public decimal GetTotalRevenue()
        {
            return _repository.GetAll().Sum(v => v.FinalPrice);
        }

        public string GetBestSellingModel()
        {
            if (!_repository.GetAll().Any()) return "No sales yet";
            return "Analysis in progress...";
        }
    }
}