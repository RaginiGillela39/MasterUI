

namespace TQMS_Organization_Application.Features.Organization.Commands.CreateOrganization
{
    public class CreateOrganizationCommand: IRequest<Response<Guid>>
    {    
        public string? Name { get; set; }
        public string? Description { get; set; }
        public Guid Type { get; set; }
    }

    public class CreateOrganizationCommandHandler(IOrganizationRepository organization,
        IOrganizationTypeRepository organizationType,
        IOrganizationValidator organizationValidator) : IRequestHandler<CreateOrganizationCommand, Response<Guid>>
    {
        private readonly IOrganizationRepository _organization=organization;
        private readonly IOrganizationValidator _organizationValidator=organizationValidator;
        private readonly IOrganizationTypeRepository _organizationType=organizationType;

        public async Task<Response<Guid>> Handle(CreateOrganizationCommand request, CancellationToken cancellationToken)
        {
            var organizationType = await _organizationType.GetByIdOrganizationTypeAsync(request.Type);
            if (organizationType == null)
            {
                return new Response<Guid>(request.Type, message: Message.organizationNotFound);
            }
            var organization = new Organization_Domain.Entities.Organization()
            {
                Id = Guid.NewGuid(),
                Name = request.Name,
                Description = request.Description,
                Type = request.Type,
                CreatedBy = "System",
                CreatedDate = DateTime.Now,
                IsActive = true
            };

            _organizationValidator.ValidateEntity(organization);
            await _organization.AddOrganizationAsync(organization);
            return new Response<Guid>(organization.Id, message: Message.organizationCreate);

        }
    }
}
