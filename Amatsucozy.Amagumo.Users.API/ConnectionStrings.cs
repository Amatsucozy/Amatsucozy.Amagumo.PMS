namespace Amatsucozy.Amagumo.Users.API;

public sealed class ConnectionStrings
{
    public required string Default { get; init; }

    public required string Redis { get; init; }
}
