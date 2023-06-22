using Amatsucozy.Amagumo.Users.Infrastructure.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Amatsucozy.Amagumo.Users.Infrastructure;

public static class DbStartupRoutines
{
    public static void DbStart(this IServiceProvider serviceProvider)
    {
        using var scope = serviceProvider.CreateScope();
        using var dbContext = scope.ServiceProvider.GetRequiredService<UsersDbContext>();

        if (dbContext.Database.GetPendingMigrations().Any())
        {
            dbContext.Database.Migrate();
        }

        Seed(dbContext);
    }

    public static void Seed(UsersDbContext usersDbContext)
    {
        if (!usersDbContext.Organisations.Any())
        {
            var organisations = new List<OrganisationModel>
            {
                new()
                {
                    Id = Guid.NewGuid(),
                    Name = "Organisation 1",
                    CreatedAt = DateTime.UtcNow,
                    UpdatedAt = DateTime.UtcNow,
                    ApiTokenKey = "api_token_key_1",
                    ApiTokenName = "api_token_name_1"
                },
                new()
                {
                    Id = Guid.NewGuid(),
                    Name = "Organisation 2",
                    CreatedAt = DateTime.UtcNow,
                    UpdatedAt = DateTime.UtcNow,
                    ApiTokenKey = "api_token_key_2",
                    ApiTokenName = "api_token_name_2"
                },
                new()
                {
                    Id = Guid.NewGuid(),
                    Name = "Organisation 3",
                    CreatedAt = DateTime.UtcNow,
                    UpdatedAt = DateTime.UtcNow,
                    ApiTokenKey = "api_token_key_3",
                    ApiTokenName = "api_token_name_3"
                }
            };

            usersDbContext.Organisations.AddRange(organisations);
            usersDbContext.SaveChanges();
        }
    }
}
