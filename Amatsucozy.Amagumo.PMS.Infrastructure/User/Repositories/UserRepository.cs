using Amatsucozy.Amagumo.PMS.Core;
using Amatsucozy.Amagumo.PMS.Core.User;
using Amatsucozy.Amagumo.PMS.Core.User.Exceptions;
using Amatsucozy.Amagumo.PMS.Infrastructure.User.Models;
using Amatsucozy.PMS.Shared.Core.Results;
using Amatsucozy.PMS.Shared.Infrastructure.Mappers;

namespace Amatsucozy.Amagumo.PMS.Infrastructure.User.Repositories;

public sealed class UserRepository : IUserRepository
{
    private readonly UserDbContext _context;
    private readonly IMapper<UserDomain, UserModel> _mapper;

    public UserRepository(UserDbContext context, IMapper<UserDomain, UserModel> mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public Result<bool> Save(UserDomain entity)
    {
        var userDbModel = _context.Users.Find(entity.Id);

        if (userDbModel is null)
        {
            var userDbModelToCreate = _mapper.Map(entity);
            _context.Users.Add(userDbModelToCreate);
            _context.SaveChanges();

            return true;
        }

        _mapper.Map(entity, userDbModel);
        _context.SaveChanges();

        return true;
    }

    public Result<UserDomain> Find(string id)
    {
        var userDbModel = _context.Users.Find(id);

        if (userDbModel is null)
        {
            return new UserNotFoundException($"User with id {id} not found");
        }

        return _mapper.Map(userDbModel);
    }
}
