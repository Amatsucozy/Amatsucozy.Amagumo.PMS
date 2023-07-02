using Amatsucozy.Amagumo.PMS.Infrastructure.User.Models;
using Microsoft.EntityFrameworkCore;

namespace Amatsucozy.Amagumo.PMS.Infrastructure.User;

public sealed class UserDbContext : DbContext
{
    public UserDbContext(DbContextOptions<UserDbContext> options) : base(options)
    {
    }

    public DbSet<UserModel> Users { get; set; } = default!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.HasDefaultSchema(UserDbContextDefaults.Schema);
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(UserDbContext).Assembly);
    }
}
