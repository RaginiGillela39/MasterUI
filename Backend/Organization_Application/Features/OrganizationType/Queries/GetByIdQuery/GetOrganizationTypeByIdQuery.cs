
namespace TQMS_Organization_Application.Features.OrganizationType.Queries.GetByIdQuery
{
    public class GetOrganizationTypeByIdQuery:IRequest<Response<Organization_Domain.Entities.OrganizationType>>
    {
        public Guid Id { get; set; }
    }

    public class GetOrganizationTypeByIdQueryHandler(IOrganizationTypeRepository organizationType) : IRequestHandler<GetOrganizationTypeByIdQuery, Response<Organization_Domain.Entities.OrganizationType>>
    {
        private readonly IOrganizationTypeRepository _organizationType=organizationType;
        public async Task<Response<Organization_Domain.Entities.OrganizationType>> Handle(GetOrganizationTypeByIdQuery request, CancellationToken cancellationToken)
        {
            var data = await _organizationType.GetByIdOrganizationTypeAsync(request.Id);
            return new Response<Organization_Domain.Entities.OrganizationType>(data);
        }
    }
}
