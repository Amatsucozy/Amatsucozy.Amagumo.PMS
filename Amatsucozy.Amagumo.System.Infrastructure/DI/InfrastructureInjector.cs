using Amatsucozy.Amagumo.System.Infrastructure.Mappers;
using Amatsucozy.Amagumo.System.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Amatsucozy.Amagumo.System.Infrastructure.DI;

public static class InfrastructureInjector
{
    public static void AddInfrastructure(this IServiceCollection serviceCollection, string? connectionString)
    {
        ArgumentException.ThrowIfNullOrEmpty(connectionString, nameof(connectionString));

        serviceCollection.AddDbContext<SystemDbContext>(optionsBuilder => optionsBuilder.UseNpgsql(connectionString));

        serviceCollection.AddScoped<IUserRepository, UserRepository>();

        serviceCollection.AddSingleton<UserMapper>();
    }
}