using Amatsucozy.Amagumo.Users.API.Mappers;
using Amatsucozy.Amagumo.Users.Contracts;
using Amatsucozy.Amagumo.Users.Core;
using Amatsucozy.Amagumo.Users.Infrastructure.Models;
using Amatsucozy.Amagumo.Users.Infrastructure.Repositories;
using Amatsucozy.PMS.Shared.API.Authorization;
using Amatsucozy.PMS.Shared.API.Controllers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Amatsucozy.Amagumo.Users.API.Controllers;

public sealed class UsersController : SecuredController
{
    private readonly IUserRepository _userRepository;
    private readonly IAuthenticatedUserProvider _authenticatedUserProvider;
    private readonly IMappingProfile<User<UserModel>, UserDto> _userDtoMapper;

    public UsersController(
        IUserRepository userRepository,
        IAuthenticatedUserProvider authenticatedUserProvider,
        IMappingProfile<User<UserModel>, UserDto> userDtoMapper)
    {
        _userRepository = userRepository;
        _authenticatedUserProvider = authenticatedUserProvider;
        _userDtoMapper = userDtoMapper;
    }

    [HttpGet]
    [Authorize(nameof(ScopesFlags.User))]
    public IActionResult GetCurrentUser()
    {
        return _userRepository.Find(_authenticatedUserProvider.User.Id)
            .ConvertTo<IActionResult>(
                user => Ok(_userDtoMapper.ToDto(user)),
                error => NotFound(error.Message)
            );
    }
    
    [HttpPost]
    [Authorize(nameof(ScopesFlags.User))]
    public IActionResult CreateNewUser([FromBody] UserDto userDto)
    {
        userDto.Id ??= _authenticatedUserProvider.User.Id;
        
        return _userRepository.Save(_userDtoMapper.ToDomainModel(userDto))
            .ConvertTo<IActionResult>(
                _ => Ok(),
                error => BadRequest(error.Message)
            );
    }
}
