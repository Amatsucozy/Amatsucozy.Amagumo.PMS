using Amatsucozy.Amagumo.PMS.Core;
using Amatsucozy.Amagumo.PMS.Core.User;
using Amatsucozy.Amagumo.PMS.Infrastructure.User.Models;
using Amatsucozy.PMS.Shared.Infrastructure.Mappers;
using Riok.Mapperly.Abstractions;

namespace Amatsucozy.Amagumo.PMS.Infrastructure.User.Mappers;

[Mapper]
public partial class UserMapper : IMapper<UserDomain, UserModel>
{
    public partial UserModel Map(UserDomain model);

    public partial void Map(UserDomain model1, UserModel model2);

    public partial UserDomain Map(UserModel model);

    public partial void Map(UserModel model2, UserDomain model1);
}
