


namespace TQMS_Organization_Application.Features.OrganizationType.Queries.GetAllActiveQuery
{
    public class GetAllActiveOrganizationTypeQuery:IRequest<Response<IEnumerable<Organization_Domain.Entities.OrganizationType>>>
    {
    }

    public class GetAllActiveOrganizationTypeQueryHandler(IOrganizationTypeRepository organizationType) : IRequestHandler<GetAllActiveOrganizationTypeQuery, Response<IEnumerable<Organization_Domain.Entities.OrganizationType>>>
    {
        private readonly IOrganizationTypeRepository _organizationType=organizationType;

        public async Task<Response<IEnumerable<Organization_Domain.Entities.OrganizationType>>> Handle(GetAllActiveOrganizationTypeQuery request, CancellationToken cancellationToken)
        {
            var activeData = await _organizationType.GetActiveOrganizationTypeAsync();
            return new Response<IEnumerable<Organization_Domain.Entities.OrganizationType>>(activeData);
        }
    }
}
