using Amatsucozy.PMS.Shared.Core.Modelling;

namespace Amatsucozy.Amagumo.Users.Core;

public sealed class User<TEntity> : IEntityDomain<string, uint, TEntity>
    where TEntity : IPostgresEntity<string>
{
    public required string Id { get; set; }

    public required string Email { get; set; }

    public required string FirstName { get; set; }

    public required string LastName { get; set; }
}
