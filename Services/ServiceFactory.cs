using Auto.Interfaces;

namespace Auto.Services
{
    public static class ServiceFactory
    {
        private static ICarService? _carService;
        private static readonly object _lock = new object();
        
        public static ICarService GetCarService()
        {
            if (_carService == null)
            {
                lock (_lock)
                {
                    if (_carService == null)
                    {
                        _carService = new CarService();
                    }
                }
            }
            return _carService;
        }
        
        public static void ResetServices()
        {
            _carService = null;
        }
    }
}