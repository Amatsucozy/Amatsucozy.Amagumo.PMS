using Amatsucozy.Amagumo.Users.Core;
using Amatsucozy.Amagumo.Users.Infrastructure.Models;
using Riok.Mapperly.Abstractions;

namespace Amatsucozy.Amagumo.Users.Infrastructure.Mappers;

[Mapper]
public partial class OrganisationMapper : IMappingProfile<Organisation<OrganisationModel>, OrganisationModel>
{
    public partial OrganisationModel ToDbModel(Organisation<OrganisationModel> domainModel);

    public partial Organisation<OrganisationModel> ToDomainModel(OrganisationModel dbModel);

    public partial void ToDbModel(Organisation<OrganisationModel> domainModel, OrganisationModel dbModel);

    public partial void ToDomainModel(OrganisationModel dbModel, Organisation<OrganisationModel> domainModel);
}
