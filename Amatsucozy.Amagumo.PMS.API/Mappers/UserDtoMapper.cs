using Amatsucozy.Amagumo.PMS.Contracts;
using Amatsucozy.Amagumo.PMS.Core;
using Amatsucozy.PMS.Shared.Infrastructure.Mappers;
using Riok.Mapperly.Abstractions;

namespace Amatsucozy.Amagumo.PMS.API.Mappers;

[Mapper]
public partial class UserDtoMapper : IMapper<User, UserDto>
{
    public partial UserDto Map(User model);

    public partial void Map(User model1, UserDto model2);

    public partial User Map(UserDto model);

    public partial void Map(UserDto model2, User model1);
}
