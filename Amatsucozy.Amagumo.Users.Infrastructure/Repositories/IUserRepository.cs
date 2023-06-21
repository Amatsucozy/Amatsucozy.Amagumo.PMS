using Amatsucozy.Amagumo.Users.Core;
using Amatsucozy.Amagumo.Users.Infrastructure.Models;
using Amatsucozy.PMS.Shared.Core.Modelling;

namespace Amatsucozy.Amagumo.Users.Infrastructure.Repositories;

public interface IUserRepository : IPostgresEntityRepository<string, UserModel, User<UserModel>>
{
}