using System.Text.Json.Serialization;

namespace Amatsucozy.Amagumo.Users.Contracts;

public sealed class UserDto
{
    [JsonIgnore]
    public string? Id { get; set; }
    
    public required string Email { get; set; }

    public required string FirstName { get; set; }

    public required string LastName { get; set; }
}
