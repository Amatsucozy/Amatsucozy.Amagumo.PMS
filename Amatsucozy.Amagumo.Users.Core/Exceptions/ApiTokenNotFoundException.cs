namespace Amatsucozy.Amagumo.Users.Core.Exceptions;

public sealed class ApiTokenNotFoundException : Exception
{
    public ApiTokenNotFoundException(string message) : base(message)
    {
    }
}
