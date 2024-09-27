using JWTAuthentication.API.Interfaces.Mappers;
using JWTAuthentication.API.Mappers;

namespace JWTAuthentication.API.DependencyInjection;

internal static class MappersDependencyInjection
{
    internal static void AddMappersDependencyInjection(this IServiceCollection services) =>
        services.AddScoped<IUserMapper, UserMapper>();
}
