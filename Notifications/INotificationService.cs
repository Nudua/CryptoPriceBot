namespace CryptoPriceBot.Notifications
{
    public interface INotificationService
    {
        bool Notify(string message);
    }
}