using System.ComponentModel.DataAnnotations;
using Amatsucozy.PMS.Shared.Core.Modelling;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Amatsucozy.Amagumo.System.Infrastructure.Models;

public sealed class UserModel : IPostgresEntity<string>
{
    [Key]
    public required string Id { get; set; }

    public DateTimeOffset CreatedAt { get; set; }

    public DateTimeOffset UpdatedAt { get; set; }

    public uint RowVersion { get; set; }

    public required string Auth0Id { get; set; }

    public required string Username { get; set; }

    public required string Email { get; set; }

    public required string FirstName { get; set; }

    public required string LastName { get; set; }
}

internal sealed class UserModelConfig : IEntityTypeConfiguration<UserModel>
{
    public void Configure(EntityTypeBuilder<UserModel> builder)
    {
        builder.ToTable(nameof(SystemDbContext.Users));
    }
}