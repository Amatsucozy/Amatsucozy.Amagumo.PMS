using Amatsucozy.Amagumo.PMS.Core;
using Amatsucozy.Amagumo.PMS.Infrastructure.Mappers;
using Amatsucozy.Amagumo.PMS.Infrastructure.Models;
using Amatsucozy.Amagumo.PMS.Infrastructure.Repositories;
using Amatsucozy.PMS.Shared.Infrastructure.Mappers;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Amatsucozy.Amagumo.PMS.Infrastructure.DI;

public static class InfrastructureInjector
{
    public static void AddInfrastructure(this IServiceCollection serviceCollection, string? connectionString)
    {
        ArgumentException.ThrowIfNullOrEmpty(connectionString, nameof(connectionString));

        serviceCollection.AddDbContext<UsersDbContext>(optionsBuilder => optionsBuilder.UseNpgsql(connectionString));

        serviceCollection.AddScoped<IUserRepository, UserRepository>();

        serviceCollection.AddSingleton<IMapper<User, UserModel>, UserMapper>();
    }
}
