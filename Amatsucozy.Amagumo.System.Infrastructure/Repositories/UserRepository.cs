using Amatsucozy.Amagumo.System.Core;
using Amatsucozy.Amagumo.System.Core.Exceptions;
using Amatsucozy.Amagumo.System.Infrastructure.Mappers;
using Amatsucozy.Amagumo.System.Infrastructure.Models;
using Amatsucozy.PMS.Shared.Core.Results;

namespace Amatsucozy.Amagumo.System.Infrastructure.Repositories;

public sealed class UserRepository : IUserRepository
{
    private readonly SystemDbContext _context;
    private readonly UserMapper _mapper;

    public UserRepository(SystemDbContext context, UserMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public Result<User<UserModel>> Find(Guid id)
    {
        var userDbModel = _context.Users.Find(id);

        if (userDbModel is null)
        {
            return new UserNotFoundException($"User with id {id} not found");
        }

        return _mapper.ToDomainModel(userDbModel);
    }

    public Result<bool> Save(User<UserModel> entity)
    {
        var userDbModel = _context.Users.Find(entity.Id);
        
        if (userDbModel is null)
        {
            return new UserNotFoundException($"User with id {entity.Id} not found");
        }
        
        _mapper.ToDbModel(entity, userDbModel);
        _context.SaveChanges();

        return true;
    }

    public Result<User<UserModel>> Find(string id)
    {
        var userDbModel = _context.Users.Find(id);

        if (userDbModel is null)
        {
            return new UserNotFoundException($"User with id {id} not found");
        }

        return _mapper.ToDomainModel(userDbModel);
    }
}