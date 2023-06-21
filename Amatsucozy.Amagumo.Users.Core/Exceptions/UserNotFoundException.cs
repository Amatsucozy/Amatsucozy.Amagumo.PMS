namespace Amatsucozy.Amagumo.Users.Core.Exceptions;

public sealed class UserNotFoundException : Exception
{
    public UserNotFoundException(string message) : base(message)
    {
    }
}