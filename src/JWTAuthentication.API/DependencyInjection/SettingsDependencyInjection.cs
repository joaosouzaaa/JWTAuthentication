using FluentValidation;
using JWTAuthentication.API.Filters;
using JWTAuthentication.API.Interfaces.Settings;
using JWTAuthentication.API.Settings.NotificationSettings;
using System.Reflection;

namespace JWTAuthentication.API.DependencyInjection;

internal static class SettingsDependencyInjection
{
    internal static void AddSettingsDependencyInjection(this IServiceCollection services)
    {
        services.AddScoped<INotificationHandler, NotificationHandler>();
        services.AddScoped<NotificationFilter>();

        services.AddValidatorsFromAssembly(Assembly.GetAssembly(typeof(Program)));
    }
}
