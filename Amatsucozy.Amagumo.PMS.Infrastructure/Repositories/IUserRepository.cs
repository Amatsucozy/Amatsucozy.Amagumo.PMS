using Amatsucozy.Amagumo.PMS.Core;
using Amatsucozy.PMS.Shared.Core.Modelling;

namespace Amatsucozy.Amagumo.PMS.Infrastructure.Repositories;

public interface IUserRepository : IEntityRepository<string, User>
{
}
