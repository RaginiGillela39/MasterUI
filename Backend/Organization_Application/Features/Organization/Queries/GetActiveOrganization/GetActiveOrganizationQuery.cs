namespace TQMS_Organization_Application.Features.Organization.Queries.GetActiveOrganization
{
    public class GetActiveOrganizationQuery:IRequest<Response<IEnumerable<Organization_Domain.Entities.Organization>>>
    {
    }

    public class GetActiveOrganizationQueryHandler(IOrganizationRepository organizationRepo) : IRequestHandler<GetActiveOrganizationQuery, Response<IEnumerable<Organization_Domain.Entities.Organization>>>
    {
        private readonly IOrganizationRepository _organizationRepo=organizationRepo;
        public async Task<Response<IEnumerable<Organization_Domain.Entities.Organization>>> Handle(GetActiveOrganizationQuery request, CancellationToken cancellationToken)
        {
            var activeOrganization = await _organizationRepo.GetActiveOrganizationAsync();
            return new Response<IEnumerable<Organization_Domain.Entities.Organization>>(activeOrganization);
        }
    }

   
}
