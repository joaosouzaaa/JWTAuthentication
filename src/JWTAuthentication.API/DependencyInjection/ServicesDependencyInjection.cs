using JWTAuthentication.API.Interfaces.Services;
using JWTAuthentication.API.Services;

namespace JWTAuthentication.API.DependencyInjection;

internal static class ServicesDependencyInjection
{
    internal static void AddServicesDependencyInjection(this IServiceCollection services)
    {
        services.AddScoped<IJwtService, JwtService>();
        services.AddScoped<IUserService, UserService>();
    }
}
