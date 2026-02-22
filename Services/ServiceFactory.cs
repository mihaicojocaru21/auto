using Auto.Interfaces;
using Auto.Repositories;

namespace Auto.Services
{
    public static class ServiceFactory
    {
        private static ICarQueryService? _carQueryService;
        private static ICarCommandService? _carCommandService;
        private static ICarRepository? _carRepository;

        private static ISaleRepository? _saleRepository;
        private static SaleService? _saleService;
        private static SaleAnalyticsService? _saleAnalyticsService;

        private static readonly object _lock = new object();
        
        public static ICarQueryService GetCarQueryService()
        {
            if (_carQueryService == null)
            {
                lock (_lock)
                {
                    if (_carQueryService == null)
                    {
                        _carRepository ??= new InMemoryCarRepository();
                        _carQueryService = new CarService(_carRepository);
                    }
                }
            }
            return _carQueryService;
        }

        public static ICarCommandService GetCarCommandService()
        {
            if (_carCommandService == null)
            {
                lock (_lock)
                {
                    if (_carCommandService == null)
                    {
                        _carRepository ??= new InMemoryCarRepository();
                        _carCommandService = new CarService(_carRepository);
                    }
                }
            }
            return _carCommandService;
        }

        public static SaleService GetSaleService()
        {
            if (_saleService == null)
            {
                lock (_lock)
                {
                    if (_saleService == null)
                    {
                        _saleRepository ??= new InMemorySaleRepository();
                        _saleService = new SaleService(_saleRepository);
                    }
                }
            }
            return _saleService;
        }

        public static SaleAnalyticsService GetSaleAnalyticsService()
        {
            if (_saleAnalyticsService == null)
            {
                lock (_lock)
                {
                    if (_saleAnalyticsService == null)
                    {
                        _saleRepository ??= new InMemorySaleRepository();
                        _saleAnalyticsService = new SaleAnalyticsService(_saleRepository);
                    }
                }
            }
            return _saleAnalyticsService;
        }
        
        public static void ResetServices()
        {
            _carQueryService = null;
            _carCommandService = null;
            _carRepository = null;
            _saleRepository = null;
            _saleService = null;
            _saleAnalyticsService = null;
        }
    }
}