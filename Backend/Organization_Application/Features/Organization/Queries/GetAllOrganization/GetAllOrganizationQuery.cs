


namespace TQMS_Organization_Application.Features.Organization.Queries.GetAllOrganization
{
    public class GetAllOrganizationQuery:IRequest<IEnumerable<Organization_Domain.Entities.Organization>>
    {
    }

    public class GetAllOrganizationQueryHandler(IOrganizationRepository organizationRepo) : IRequestHandler<GetAllOrganizationQuery, IEnumerable<Organization_Domain.Entities.Organization>>
    {
        private readonly IOrganizationRepository _organizationRepo=organizationRepo;

        public async Task<IEnumerable<Organization_Domain.Entities.Organization>> Handle(GetAllOrganizationQuery request, CancellationToken cancellationToken)
        {
            return await _organizationRepo.GetAllOrganizationsAsync();
        }
    }

}
