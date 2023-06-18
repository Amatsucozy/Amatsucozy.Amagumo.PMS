using Amatsucozy.Amagumo.System.Core;
using Amatsucozy.Amagumo.System.Infrastructure.Models;
using Riok.Mapperly.Abstractions;

namespace Amatsucozy.Amagumo.System.Infrastructure.Mappers;

[Mapper(UseDeepCloning = true)]
public partial class UserMapper : IMappingProfile<User<UserModel>, UserModel>
{
    public partial void ToDbModel(User<UserModel> domainModel, UserModel dbModel);

    public partial User<UserModel> ToDomainModel(UserModel domainModel);
}