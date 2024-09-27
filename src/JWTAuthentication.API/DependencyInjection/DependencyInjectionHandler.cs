using JWTAuthentication.API.Constants;
using JWTAuthentication.API.Data.DatabaseContexts;
using Microsoft.EntityFrameworkCore;

namespace JWTAuthentication.API.DependencyInjection;

internal static class DependencyInjectionHandler
{
    internal static void AddDependencyInjection(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddCorsDependencyInjection();
        services.AddSwaggerDependencyInjection();

        services.AddDbContext<ApplicationDbContext>(options =>
            options.UseNpgsql(configuration.GetConnectionString(OptionsConstants.DefaultConnectionSection)));

        services.AddIdentityDependencyInjection();
        services.AddOptionsDependencyInjection(configuration);
        services.AddAuthenticationDependencyInjection(configuration);
        services.AddSettingsDependencyInjection();
        services.AddRepositoriesDependencyInjection();
        services.AddMappersDependencyInjection();
        services.AddServicesDependencyInjection();
    }
}
