using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Amatsucozy.Amagumo.System.Infrastructure;

public class SystemDbContextFactory : IDesignTimeDbContextFactory<SystemDbContext>
{
    public SystemDbContext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<SystemDbContext>()
            .UseNpgsql(DbConstants.ConnectionString);

        return new SystemDbContext(optionsBuilder.Options);
    }
}