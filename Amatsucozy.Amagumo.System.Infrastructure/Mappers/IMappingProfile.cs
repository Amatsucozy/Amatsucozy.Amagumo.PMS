namespace Amatsucozy.Amagumo.System.Infrastructure.Mappers;

public interface IMappingProfile<TDomainModel, in TDbModel>
    where TDomainModel : notnull
    where TDbModel : notnull
{
    void ToDbModel(TDomainModel domainModel, TDbModel dbModel);

    TDomainModel ToDomainModel(TDbModel domainModel);
}