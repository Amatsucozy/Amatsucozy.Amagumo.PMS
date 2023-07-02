using Amatsucozy.Amagumo.PMS.API.Mappers;
using Amatsucozy.Amagumo.PMS.Contracts;
using Amatsucozy.Amagumo.PMS.Core;
using Amatsucozy.PMS.Shared.Infrastructure.Mappers;

namespace Amatsucozy.Amagumo.PMS.API.DI;

public static class DependenciesInjector
{
    public static void AddApiDependencies(this IServiceCollection serviceCollection)
    {
        serviceCollection.AddSingleton<IMapper<User, UserDto>, UserDtoMapper>();
    }
}
