using JWTAuthentication.API.Data.Repositories;
using JWTAuthentication.API.Interfaces.Repositories;

namespace JWTAuthentication.API.DependencyInjection;

internal static class RepositoriesDependencyInjection
{
    internal static void AddRepositoriesDependencyInjection(this IServiceCollection services) =>
        services.AddScoped<IUserRepository, UserRepository>();
}
