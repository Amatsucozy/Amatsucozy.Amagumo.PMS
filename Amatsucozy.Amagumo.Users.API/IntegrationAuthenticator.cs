using Amatsucozy.Amagumo.Users.Infrastructure.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Amatsucozy.Amagumo.Users.API;

public sealed class IntegrationAuthenticator : ActionFilterAttribute
{
    public IntegrationAuthenticator()
    {
    }

    public override void OnActionExecuting(ActionExecutingContext context)
    {
        var request = context.HttpContext.Request;
        var organisationRepository = context.HttpContext.RequestServices.GetRequiredService<IOrganisationRepository>();
        var apiTokenParts = request.Headers.Authorization.FirstOrDefault()?.Split(' ');

        if (apiTokenParts is null)
        {
            context.Result = new UnauthorizedObjectResult("API token is not provided");
            base.OnActionExecuting(context);
            return;
        }

        var apiTokenName = apiTokenParts[0];

        var storedApiTokenKey = organisationRepository.GetApiTokenKey(apiTokenName);

        var authResult = storedApiTokenKey.ConvertTo<ObjectResult?>(
            apiToken => apiToken == apiTokenParts[1] ? null : new UnauthorizedObjectResult("Invalid API token"),
            exception => new UnauthorizedObjectResult(exception.Message));

        if (authResult is not null)
        {
            context.Result = authResult;
            base.OnActionExecuting(context);
            return;
        }

        base.OnActionExecuting(context);
    }
}
