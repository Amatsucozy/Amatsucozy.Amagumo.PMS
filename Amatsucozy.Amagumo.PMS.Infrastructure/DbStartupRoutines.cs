using Amatsucozy.Amagumo.PMS.Infrastructure.User;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Amatsucozy.Amagumo.PMS.Infrastructure;

public static class DbStartupRoutines
{
    public static void DbStart(this IServiceProvider serviceProvider)
    {
        using var scope = serviceProvider.CreateScope();
        using var dbContext = scope.ServiceProvider.GetRequiredService<UserDbContext>();

        if (dbContext.Database.GetPendingMigrations().Any())
        {
            dbContext.Database.Migrate();
        }
    }
}
