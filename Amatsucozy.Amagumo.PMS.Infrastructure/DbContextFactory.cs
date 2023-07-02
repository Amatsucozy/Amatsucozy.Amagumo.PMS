using Amatsucozy.Amagumo.PMS.Infrastructure.User;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Amatsucozy.Amagumo.PMS.Infrastructure;

public class DbContextFactory : IDesignTimeDbContextFactory<UserDbContext>
{
    public UserDbContext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<UserDbContext>()
            .UseNpgsql(DevelopmentConstants.ConnectionString);

        return new UserDbContext(optionsBuilder.Options);
    }
}
