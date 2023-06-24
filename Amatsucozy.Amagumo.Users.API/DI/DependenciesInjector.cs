using Amatsucozy.Amagumo.Users.API.Mappers;
using Amatsucozy.Amagumo.Users.Contracts;
using Amatsucozy.Amagumo.Users.Core;
using Amatsucozy.PMS.Shared.Infrastructure.Mappers;

namespace Amatsucozy.Amagumo.Users.API.DI;

public static class DependenciesInjector
{
    public static void AddApiDependencies(this IServiceCollection serviceCollection)
    {
        serviceCollection.AddSingleton<IMapper<User, UserDto>, UserDtoMapper>();
    }
}
