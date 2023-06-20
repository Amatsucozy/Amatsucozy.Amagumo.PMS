using System.Security.Claims;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Options;

namespace Amatsucozy.Amagumo.System.API.Authorization;

public sealed class UserTokenProvider
{
    public ScopesEnum UserScopes { get; } = ScopesEnum.None;

    public string UserId { get; } = string.Empty;

    public bool IsValid { get; } = false;

    private const string ScopeClaimType = "scope";

    public UserTokenProvider(IHttpContextAccessor httpContextAccessor, IOptions<JwtBearerOptions> jwtOptions)
    {
        var context = httpContextAccessor.HttpContext;

        if (context is null)
        {
            return;
        }
        
        UserId = context.User.FindFirst(ClaimTypes.NameIdentifier)?.Value ?? string.Empty;
        UserScopes = context.User
            .FindFirst(c => c.Type == ScopeClaimType && c.Issuer == jwtOptions.Value.Authority)?.Value
            .Split(' ')
            .Aggregate(
                ScopesEnum.None,
                (scopesEnum, scope) =>
                {
                    if (!Scopes.ScopesDictionary.TryGetValue(scope, out var scopeEnum))
                    {
                        return scopesEnum;
                    }

                    scopesEnum |= Scopes.ScopesDictionary[scope];

                    return scopesEnum;
                }) ?? ScopesEnum.None;
        IsValid = !string.IsNullOrWhiteSpace(UserId) && UserScopes != ScopesEnum.None;
    }
}
