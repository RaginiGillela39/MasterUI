namespace TQMS_Organization_Application.Features.OrganizationType.Queries.GetAllQuery
{
    public class GetAllOrganizationTypeQuery : IRequest<IEnumerable<Organization_Domain.Entities.OrganizationType>>
    {
    }

    public class GetAllOrganizationTypeQueryHandler(IOrganizationTypeRepository organizationType) : IRequestHandler<GetAllOrganizationTypeQuery, IEnumerable<Organization_Domain.Entities.OrganizationType>>
    {
        private readonly IOrganizationTypeRepository _organizationType = organizationType;

        public async Task<IEnumerable<Organization_Domain.Entities.OrganizationType>> Handle(GetAllOrganizationTypeQuery request, CancellationToken cancellationToken)
        {
            return await _organizationType.GetAllOrganizationTypesAsync();
        }
    }
}
