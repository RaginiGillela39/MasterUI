
namespace TQMS_Organization_Application.Features.Organization.Queries.GetOrganizationById
{
    public class GetOrganizationByIdQuery : IRequest<Response<Organization_Domain.Entities.Organization>> 
    { 
        public Guid Id { get; set; }
    }

    public class GetOrganizationByIdQueryHandler(IOrganizationRepository organizationRepo) : IRequestHandler<GetOrganizationByIdQuery, Response<Organization_Domain.Entities.Organization>>
    {
        private readonly IOrganizationRepository _organizationRepo=organizationRepo;
        public async Task<Response<Organization_Domain.Entities.Organization>> Handle(GetOrganizationByIdQuery request, CancellationToken cancellationToken)
        {
            var organization = await _organizationRepo.GetByIdOrganizationAsync(request.Id);
            return new Response<Organization_Domain.Entities.Organization>(organization);

        }
    }
}
