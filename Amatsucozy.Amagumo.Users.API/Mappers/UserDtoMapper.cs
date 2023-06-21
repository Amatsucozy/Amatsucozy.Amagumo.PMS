using Amatsucozy.Amagumo.Users.Contracts;
using Amatsucozy.Amagumo.Users.Core;
using Amatsucozy.Amagumo.Users.Infrastructure.Models;
using Riok.Mapperly.Abstractions;

namespace Amatsucozy.Amagumo.Users.API.Mappers;

[Mapper]
public partial class UserDtoMapper : IMappingProfile<User<UserModel>, UserDto>
{
    public partial UserDto ToDto(User<UserModel> domainModel);

    public partial User<UserModel> ToDomainModel(UserDto dto);

    public partial void ToDto(User<UserModel> domainModel, UserDto dto);

    public partial void ToDomainModel(UserDto dto, User<UserModel> domainModel);
}
