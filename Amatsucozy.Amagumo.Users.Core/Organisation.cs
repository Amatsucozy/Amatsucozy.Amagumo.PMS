using Amatsucozy.PMS.Shared.Core.Modelling;

namespace Amatsucozy.Amagumo.Users.Core;

public sealed class Organisation<TEntity> : IEntityDomain<Guid, uint, TEntity>
    where TEntity : IPostgresEntity<Guid>
{
    public Guid Id { get; set; }

    public required string Name { get; set; }

    public required string ApiTokenName { get; set; }

    public required string ApiTokenKey { get; set; }
}
