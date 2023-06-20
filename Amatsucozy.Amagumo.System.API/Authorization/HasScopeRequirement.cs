using Microsoft.AspNetCore.Authorization;

namespace Amatsucozy.Amagumo.System.API.Authorization;

public sealed class HasScopeRequirement : IAuthorizationRequirement
{
    public string Issuer { get; }

    public ScopesEnum Scopes { get; }

    public HasScopeRequirement(string issuer, ScopesEnum scopes)
    {
        Scopes = scopes;
        Issuer = issuer ?? throw new ArgumentNullException(nameof(issuer));
    }
}
