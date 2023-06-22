using Amatsucozy.Amagumo.Users.Core;
using Amatsucozy.Amagumo.Users.Infrastructure.Models;
using Riok.Mapperly.Abstractions;

namespace Amatsucozy.Amagumo.Users.Infrastructure.Mappers;

[Mapper]
public partial class UserMapper : IMappingProfile<User<UserModel>, UserModel>
{
    public partial UserModel ToDbModel(User<UserModel> domainModel);

    public partial User<UserModel> ToDomainModel(UserModel dbModel);

    public partial void ToDbModel(User<UserModel> domainModel, UserModel dbModel);

    public partial void ToDomainModel(UserModel dbModel, User<UserModel> domainModel);
}
