using Amatsucozy.Amagumo.System.Core;
using Amatsucozy.Amagumo.System.Infrastructure.Models;
using Microsoft.EntityFrameworkCore;

namespace Amatsucozy.Amagumo.System.Infrastructure;

public sealed class SystemDbContext : DbContext
{
    public SystemDbContext(DbContextOptions<SystemDbContext> options) : base(options)
    {
    }

    public DbSet<UserModel> Users { get; set; } = default!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.HasDefaultSchema(DbConstants.Schema);
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(SystemDbContext).Assembly);
    }
}