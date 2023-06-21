namespace Amatsucozy.Amagumo.Users.API.Mappers;

public interface IMappingProfile<TDomainModel, TDto>
    where TDomainModel : notnull
    where TDto : notnull
{
    TDto ToDto(TDomainModel domainModel);
    
    TDomainModel ToDomainModel(TDto dto);
    
    void ToDto(TDomainModel domainModel, TDto dto);

    void ToDomainModel(TDto dto, TDomainModel domainModel);
}
