namespace Amatsucozy.Amagumo.Users.Infrastructure.Mappers;

public interface IMappingProfile<TDomainModel, TDbModel>
    where TDomainModel : notnull
    where TDbModel : notnull
{
    TDbModel ToDbModel(TDomainModel domainModel);
    
    TDomainModel ToDomainModel(TDbModel dbModel);
    
    void ToDbModel(TDomainModel domainModel, TDbModel dbModel);

    void ToDomainModel(TDbModel dbModel, TDomainModel domainModel);
}
