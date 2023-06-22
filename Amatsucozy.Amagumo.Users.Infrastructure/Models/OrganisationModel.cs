using System.ComponentModel.DataAnnotations;
using Amatsucozy.PMS.Shared.Core.Modelling;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Amatsucozy.Amagumo.Users.Infrastructure.Models;

public sealed class OrganisationModel : IPostgresEntity<Guid>
{
    [Key]
    public Guid Id { get; set; }

    public DateTimeOffset CreatedAt { get; set; }

    public DateTimeOffset UpdatedAt { get; set; }

    public uint RowVersion { get; set; }

    public required string Name { get; set; }

    public required string ApiTokenName { get; set; }

    public required string ApiTokenKey { get; set; }
}

internal sealed class OrganisationModelConfig : IEntityTypeConfiguration<UserModel>
{
    public void Configure(EntityTypeBuilder<UserModel> builder)
    {
        builder.ToTable(nameof(UsersDbContext.Organisations));
    }
}
