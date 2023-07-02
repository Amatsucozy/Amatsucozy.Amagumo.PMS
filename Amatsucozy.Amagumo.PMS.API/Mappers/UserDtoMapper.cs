using Amatsucozy.Amagumo.PMS.Contracts;
using Amatsucozy.Amagumo.PMS.Contracts.User;
using Amatsucozy.Amagumo.PMS.Core;
using Amatsucozy.Amagumo.PMS.Core.User;
using Amatsucozy.PMS.Shared.Infrastructure.Mappers;
using Riok.Mapperly.Abstractions;

namespace Amatsucozy.Amagumo.PMS.API.Mappers;

[Mapper]
public partial class UserDtoMapper : IMapper<UserDomain, UserDto>
{
    public partial UserDto Map(UserDomain model);

    public partial void Map(UserDomain model1, UserDto model2);

    public partial UserDomain Map(UserDto model);

    public partial void Map(UserDto model2, UserDomain model1);
}
