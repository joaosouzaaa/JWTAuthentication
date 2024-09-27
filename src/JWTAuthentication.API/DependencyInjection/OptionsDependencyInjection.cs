using JWTAuthentication.API.Constants;
using JWTAuthentication.API.Options;

namespace JWTAuthentication.API.DependencyInjection;

internal static class OptionsDependencyInjection
{
    internal static void AddOptionsDependencyInjection(this IServiceCollection services, IConfiguration configuration) =>
        services.Configure<TokenOptions>(configuration.GetSection(OptionsConstants.TokenSection));
}
