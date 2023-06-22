using Amatsucozy.Amagumo.Users.Core;
using Amatsucozy.Amagumo.Users.Core.Exceptions;
using Amatsucozy.Amagumo.Users.Infrastructure.Mappers;
using Amatsucozy.Amagumo.Users.Infrastructure.Models;
using Amatsucozy.PMS.Shared.Core.Results;

namespace Amatsucozy.Amagumo.Users.Infrastructure.Repositories;

public sealed class OrganisationRepository : IOrganisationRepository
{
    private readonly UsersDbContext _context;
    private readonly IMappingProfile<Organisation<OrganisationModel>, OrganisationModel> _mapper;

    public OrganisationRepository(
        UsersDbContext context,
        IMappingProfile<Organisation<OrganisationModel>, OrganisationModel> mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public Result<Organisation<OrganisationModel>> Find(Guid id)
    {
        var organisationDbModel = _context.Organisations.Find(id);
        
        if (organisationDbModel is null)
        {
            return new OrganisationNotFoundException($"Organisation with id {id} not found");
        }
        
        return _mapper.ToDomainModel(organisationDbModel);
    }

    public Result<bool> Save(Organisation<OrganisationModel> entity)
    {
        var organisationDbModel = _context.Organisations.Find(entity.Id);
        
        if (organisationDbModel is null)
        {
            var organisationDbModelToCreate = _mapper.ToDbModel(entity);
            _context.Organisations.Add(organisationDbModelToCreate);
            _context.SaveChanges();
            
            return true;
        }
        
        _mapper.ToDbModel(entity, organisationDbModel);
        _context.SaveChanges();

        return true;
    }

    public Result<string> GetApiTokenKey(string apiTokenName)
    {
        var organisationDbModel = _context.Organisations.FirstOrDefault(x => x.ApiTokenName == apiTokenName);

        if (organisationDbModel is null)
        {
            return new ApiTokenNotFoundException($"Api token with name {apiTokenName} not found");
        }

        return organisationDbModel.ApiTokenKey;
    }
}
