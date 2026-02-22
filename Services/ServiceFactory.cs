using Auto.Interfaces;
using Auto.Repositories;

namespace Auto.Services
{
    public static class ServiceFactory
    {
        private static ICarService? _carService;
        private static ICarRepository? _carRepository;
        private static readonly object _lock = new object();
        
        public static ICarService GetCarService()
        {
            if (_carService == null)
            {
                lock (_lock)
                {
                    if (_carService == null)
                    {
                        _carRepository ??= new InMemoryCarRepository();
                        _carService = new CarService(_carRepository);
                    }
                }
            }
            return _carService;
        }
        
        public static void ResetServices()
        {
            _carService = null;
            _carRepository = null;
        }
    }
}