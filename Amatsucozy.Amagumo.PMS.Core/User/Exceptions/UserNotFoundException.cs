namespace Amatsucozy.Amagumo.PMS.Core.User.Exceptions;

public sealed class UserNotFoundException : Exception
{
    public UserNotFoundException(string message) : base(message)
    {
    }
}