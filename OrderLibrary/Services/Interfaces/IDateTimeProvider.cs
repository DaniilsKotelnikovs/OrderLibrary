namespace OrderLibrary.Services.Interfaces
{
    public interface IDateTimeProvider
    {
        DateTime Now { get; }
    }
}