﻿using JWTAuthentication.API.Data.DatabaseContexts;
using Microsoft.EntityFrameworkCore;

namespace JWTAuthentication.API.DependencyInjection;

internal static class MigrationHandler
{
    internal static void MigrateDatabase(this IApplicationBuilder app)
    {
        using var scope = app.ApplicationServices.CreateScope();

        using var dbContext = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();

        try
        {
            dbContext.Database.Migrate();
        }
        catch
        {
            throw;
        }
    }
}
