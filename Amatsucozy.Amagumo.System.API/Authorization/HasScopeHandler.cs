using Microsoft.AspNetCore.Authorization;

namespace Amatsucozy.Amagumo.System.API.Authorization;

public sealed class HasScopeHandler : AuthorizationHandler<HasScopeRequirement>
{
    private const string ScopeClaimType = "scope";

    private readonly UserTokenProvider _userTokenProvider;

    public HasScopeHandler(UserTokenProvider userTokenProvider)
    {
        _userTokenProvider = userTokenProvider;
    }

    protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, HasScopeRequirement requirement)
    {
        if (!_userTokenProvider.IsValid)
        {
            return Task.CompletedTask;
        }

        if ((_userTokenProvider.UserScopes & requirement.Scopes) == requirement.Scopes)
        {
            context.Succeed(requirement);
        }

        return Task.CompletedTask;
    }
}
