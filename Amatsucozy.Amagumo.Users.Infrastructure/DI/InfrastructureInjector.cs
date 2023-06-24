using Amatsucozy.Amagumo.Users.Core;
using Amatsucozy.Amagumo.Users.Infrastructure.Mappers;
using Amatsucozy.Amagumo.Users.Infrastructure.Models;
using Amatsucozy.Amagumo.Users.Infrastructure.Repositories;
using Amatsucozy.PMS.Shared.Infrastructure.Mappers;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Amatsucozy.Amagumo.Users.Infrastructure.DI;

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
