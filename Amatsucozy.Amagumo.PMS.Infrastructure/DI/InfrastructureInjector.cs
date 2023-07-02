using Amatsucozy.Amagumo.PMS.Core;
using Amatsucozy.Amagumo.PMS.Core.User;
using Amatsucozy.Amagumo.PMS.Infrastructure.User;
using Amatsucozy.Amagumo.PMS.Infrastructure.User.Mappers;
using Amatsucozy.Amagumo.PMS.Infrastructure.User.Models;
using Amatsucozy.Amagumo.PMS.Infrastructure.User.Repositories;
using Amatsucozy.PMS.Shared.Infrastructure.Mappers;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Amatsucozy.Amagumo.PMS.Infrastructure.DI;

public static class InfrastructureInjector
{
    public static void AddInfrastructure(this IServiceCollection serviceCollection, string? connectionString)
    {
        ArgumentException.ThrowIfNullOrEmpty(connectionString, nameof(connectionString));

        serviceCollection.AddDbContext<UserDbContext>(optionsBuilder => optionsBuilder.UseNpgsql(connectionString));

        serviceCollection.AddScoped<IUserRepository, UserRepository>();

        serviceCollection.AddSingleton<IMapper<UserDomain, UserModel>, UserMapper>();
    }
}
