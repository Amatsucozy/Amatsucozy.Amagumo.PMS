using Amatsucozy.PMS.Shared.Core.Modelling;

namespace Amatsucozy.Amagumo.Users.Core;

public sealed class User : IEntityDomain<string>
{
    public required string Id { get; set; }

    public DateTimeOffset CreatedAt { get; set; }

    public DateTimeOffset UpdatedAt { get; set; }

    public required string Email { get; set; }

    public required string FirstName { get; set; }

    public required string LastName { get; set; }
}
