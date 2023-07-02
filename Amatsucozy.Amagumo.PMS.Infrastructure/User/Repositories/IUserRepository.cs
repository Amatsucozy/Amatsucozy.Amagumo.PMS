using Amatsucozy.Amagumo.PMS.Core;
using Amatsucozy.Amagumo.PMS.Core.User;
using Amatsucozy.PMS.Shared.Core.Modelling;

namespace Amatsucozy.Amagumo.PMS.Infrastructure.User.Repositories;

public interface IUserRepository : IEntityRepository<string, UserDomain>
{
}
