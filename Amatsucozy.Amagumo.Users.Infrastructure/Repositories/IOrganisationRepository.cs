using Amatsucozy.Amagumo.Users.Core;
using Amatsucozy.Amagumo.Users.Infrastructure.Models;
using Amatsucozy.PMS.Shared.Core.Modelling;
using Amatsucozy.PMS.Shared.Core.Results;

namespace Amatsucozy.Amagumo.Users.Infrastructure.Repositories;

public interface IOrganisationRepository : IPostgresEntityRepository<Guid, OrganisationModel, Organisation<OrganisationModel>>
{
    public Result<string> GetApiTokenKey(string apiTokenName);
}
