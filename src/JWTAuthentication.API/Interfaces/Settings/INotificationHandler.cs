using JWTAuthentication.API.Settings.NotificationSettings;

namespace JWTAuthentication.API.Interfaces.Settings;

public interface INotificationHandler
{
    void AddNotification(string key, string message);
    List<Notification> GetNotifications();
    bool HasNotifications();
}
