using Amatsucozy.Amagumo.System.Core;
using Amatsucozy.Amagumo.System.Infrastructure.Models;
using Amatsucozy.PMS.Shared.Core.Modelling;

namespace Amatsucozy.Amagumo.System.Infrastructure.Repositories;

public interface IUserRepository : IPostgresEntityRepository<string, UserModel, User<UserModel>>
{
}