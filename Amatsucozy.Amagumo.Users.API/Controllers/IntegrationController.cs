using Amatsucozy.Amagumo.Users.Infrastructure.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Amatsucozy.Amagumo.Users.API.Controllers;

[ApiController]
[Route("api/v1/[controller]")]
public sealed class IntegrationController : ControllerBase
{
    private readonly IOrganisationRepository _organisationRepository;
    
    public IntegrationController(IOrganisationRepository organisationRepository)
    {
        _organisationRepository = organisationRepository;
    }
    
    [IntegrationAuthenticator]
    [HttpGet("organisations")]
    public IActionResult GetOrganisation(Guid id)
    {
        return _organisationRepository.Find(id)
            .ConvertTo<IActionResult>(
                organisation => Ok(organisation),
                error => NotFound(error.Message)
            );
    }
}
