﻿using Amatsucozy.Amagumo.Users.Contracts;
using Amatsucozy.Amagumo.Users.Core;
using Amatsucozy.Amagumo.Users.Infrastructure.Repositories;
using Amatsucozy.PMS.Shared.API.Authorization;
using Amatsucozy.PMS.Shared.API.Controllers;
using Amatsucozy.PMS.Shared.Infrastructure.Mappers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Amatsucozy.Amagumo.Users.API.Controllers;

public sealed class UsersController : SecuredController
{
    private readonly IUserRepository _userRepository;
    private readonly IAuthenticatedUserProvider _authenticatedUserProvider;
    private readonly IMapper<User, UserDto> _userDtoMapper;

    public UsersController(
        IUserRepository userRepository,
        IAuthenticatedUserProvider authenticatedUserProvider,
        IMapper<User, UserDto> userDtoMapper)
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
                user => Ok(_userDtoMapper.Map(user)),
                error => NotFound(error.Message)
            );
    }
    
    [HttpPost]
    [Authorize(nameof(ScopesFlags.User))]
    public IActionResult CreateNewUser([FromBody] UserDto userDto)
    {
        userDto.Id ??= _authenticatedUserProvider.User.Id;
        
        return _userRepository.Save(_userDtoMapper.Map(userDto))
            .ConvertTo<IActionResult>(
                _ => Ok(),
                error => BadRequest(error.Message)
            );
    }
}
