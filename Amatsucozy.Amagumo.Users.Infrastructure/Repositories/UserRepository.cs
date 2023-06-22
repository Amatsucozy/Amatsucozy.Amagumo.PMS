using Amatsucozy.Amagumo.Users.Core;
using Amatsucozy.Amagumo.Users.Core.Exceptions;
using Amatsucozy.Amagumo.Users.Infrastructure.Mappers;
using Amatsucozy.Amagumo.Users.Infrastructure.Models;
using Amatsucozy.PMS.Shared.Core.Results;

namespace Amatsucozy.Amagumo.Users.Infrastructure.Repositories;

public sealed class UserRepository : IUserRepository
{
    private readonly UsersDbContext _context;
    private readonly IMappingProfile<User<UserModel>, UserModel> _mapper;

    public UserRepository(UsersDbContext context, IMappingProfile<User<UserModel>, UserModel> mapper)
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
            var userDbModelToCreate = _mapper.ToDbModel(entity);
            _context.Users.Add(userDbModelToCreate);
            _context.SaveChanges();
            
            return true;
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
