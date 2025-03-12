namespace TQMS_Organization_Application.Features.Organization.Commands.UpdateOrganization
{
    public class UpdateOrganizationCommand : IRequest<Response<Guid>>
    {
        public Guid Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public Guid Type { get; set; }
    }

    public class UpdateOrganizationCommandHandler(IOrganizationRepository organization,
        IOrganizationTypeRepository organizationType,
        IOrganizationValidator organizationValidator) : IRequestHandler<UpdateOrganizationCommand, Response<Guid>>
        {
        private readonly IOrganizationRepository _organization = organization;
        private readonly IOrganizationValidator _organizationValidator = organizationValidator;
        private readonly IOrganizationTypeRepository _organizationType = organizationType;

        public async Task<Response<Guid>> Handle(UpdateOrganizationCommand request, CancellationToken cancellationToken)
        {
            var organization = await _organization.GetByIdOrganizationAsync(request.Id);
            if (organization == null)
            {
                return new Response<Guid>(request.Id, message: Message.organizationNotFound);
            }
            var organizationData = new Organization_Domain.Entities.Organization()
            {
                Id = request.Id,
                Name = request.Name,
                Description = request.Description,
                Type = request.Type,
                ModifiedBy = "System",
                ModifiedDate = DateTime.Now,
                IsActive = true
            };

            _organizationValidator.ValidateEntity(organizationData);
            await _organization.UpdateOrganizationAsync(organizationData);
            return new Response<Guid>(organization.Id, message: Message.organizationUpdate);
        }
    }
}
