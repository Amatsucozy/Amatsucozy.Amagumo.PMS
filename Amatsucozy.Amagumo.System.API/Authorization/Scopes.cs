namespace Amatsucozy.Amagumo.System.API.Authorization;

public static class Scopes
{
    public const string ReadCurrentUser = "read:current_user";

    public const string ReadAllUsers = "read:all_users";

    public const string WriteCurrentUser = "write:current_user";

    public const string WriteAllUsers = "write:all_users";

    public static readonly IReadOnlyDictionary<string, ScopesEnum> ScopesDictionary = new Dictionary<string, ScopesEnum>
    {
        { ReadCurrentUser, ScopesEnum.ReadCurrentUser },
        { ReadAllUsers, ScopesEnum.ReadAllUsers },
        { WriteCurrentUser, ScopesEnum.WriteCurrentUser },
        { WriteAllUsers, ScopesEnum.WriteAllUsers }
    };
}

[Flags]
public enum ScopesEnum
{
    None = 0b_0,
    ReadCurrentUser = 0b_1,
    ReadAllUsers = 0b_10,
    WriteCurrentUser = 0b_100,
    WriteAllUsers = 0b_1000,

    User = ReadCurrentUser | WriteCurrentUser,
    Admin = ReadAllUsers | WriteAllUsers | User
}
