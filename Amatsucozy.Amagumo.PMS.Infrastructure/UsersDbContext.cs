using Amatsucozy.Amagumo.PMS.Infrastructure.Models;
using Microsoft.EntityFrameworkCore;

namespace Amatsucozy.Amagumo.PMS.Infrastructure;

public sealed class UsersDbContext : DbContext
{
    public UsersDbContext(DbContextOptions<UsersDbContext> options) : base(options)
    {
    }

    public DbSet<UserModel> Users { get; set; } = default!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.HasDefaultSchema(DbConstants.Schema);
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(UsersDbContext).Assembly);
    }
}
