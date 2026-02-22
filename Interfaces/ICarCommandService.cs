namespace Auto.Interfaces
{
    public interface ICarCommandService
    {
        bool SellCar(int id);
        void Reset();
    }
}