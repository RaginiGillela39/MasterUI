
namespace TQMS_Organization_Application.Features.OrganizationType.Commands.CreateOrganizationTYpe
{
    public class CreateOrganizationTypeCommand:IRequest<Response<Guid>>
    {
        public Guid Id { get; set; }
        public string? Name { get; set; }
    }

    public class CreateOrganizationTypeCommandHandler(IOrganizationTypeRepository organizationType
        , IOrganizationTypevalidator organizationTypevalidator) : IRequestHandler<CreateOrganizationTypeCommand, Response<Guid>>
    {
        private readonly IOrganizationTypevalidator _organizationTypevalidator= organizationTypevalidator;
        private readonly IOrganizationTypeRepository _organizationType=organizationType;
        public async Task<Response<Guid>> Handle(CreateOrganizationTypeCommand request, CancellationToken cancellationToken)
        {
            var organizationTypeData = new Organization_Domain.Entities.OrganizationType();
            organizationTypeData.Id = request.Id;
            organizationTypeData.Name = request.Name;
            organizationTypeData.CreatedDate= DateTime.UtcNow;
            organizationTypeData.CreatedBy = "System";
            organizationTypeData.IsActive = true;

            _organizationTypevalidator.ValidateEntity(organizationTypeData);
            await _organizationType.AddOrganizationTypeAsync(organizationTypeData);
            return new Response<Guid>(organizationTypeData.Id, message:Message.organizationTypeCreate);
        }
    }
}

