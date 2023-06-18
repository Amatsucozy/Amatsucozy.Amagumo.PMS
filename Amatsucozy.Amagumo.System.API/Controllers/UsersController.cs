using Amatsucozy.Amagumo.System.Infrastructure;
using Amatsucozy.Amagumo.System.Infrastructure.Models;
using Amatsucozy.Amagumo.System.Infrastructure.Repositories;
using Amatsucozy.PMS.Shared.API.Controllers;
using Microsoft.AspNetCore.Mvc;

namespace Amatsucozy.Amagumo.System.API.Controllers;

public sealed class UsersController : SecuredController
{
    private readonly IUserRepository _userRepository;
    private readonly SystemDbContext _context;

    public UsersController(IUserRepository userRepository, SystemDbContext context)
    {
        _userRepository = userRepository;
        _context = context;
    }

    [HttpGet]
    public IActionResult Get()
    {
        return _userRepository.Find("auth0|id")
            .ConvertTo<IActionResult>(
                user => Ok(user),
                error => NotFound(error.Message)
            );
    }
}