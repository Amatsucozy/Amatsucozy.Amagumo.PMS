using Amatsucozy.Amagumo.Users.API.Mappers;
using Amatsucozy.Amagumo.Users.Contracts;
using Amatsucozy.Amagumo.Users.Core;
using Amatsucozy.Amagumo.Users.Infrastructure.Models;

namespace Amatsucozy.Amagumo.Users.API.DI;

public static class DependenciesInjector
{
    public static void AddApiDependencies(this IServiceCollection serviceCollection)
    {
        serviceCollection.AddSingleton<IMappingProfile<User<UserModel>, UserDto>, UserDtoMapper>();
    }
}
