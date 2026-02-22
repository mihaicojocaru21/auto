namespace Auto.Interfaces
{
    public interface ICar
    {
        int Id { get; set; }
        bool Sold { get; set; }
        decimal Price { get; }

        string GetInfo();
    }
}