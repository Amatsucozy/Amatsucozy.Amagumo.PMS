namespace Amatsucozy.Amagumo.Users.Core.Exceptions;

public sealed class OrganisationNotFoundException : Exception
{
    public OrganisationNotFoundException(string message) : base(message)
    {
    }
}
