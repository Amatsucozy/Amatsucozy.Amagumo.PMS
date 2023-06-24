using Amatsucozy.Amagumo.Users.Core;
using Amatsucozy.PMS.Shared.Core.Modelling;

namespace Amatsucozy.Amagumo.Users.Infrastructure.Repositories;

public interface IUserRepository : IEntityRepository<string, User>
{
}
