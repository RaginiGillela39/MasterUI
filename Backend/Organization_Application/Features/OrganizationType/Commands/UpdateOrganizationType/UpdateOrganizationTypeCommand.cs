
using TQMS_Organization_Application.Extensions;

namespace TQMS_Organization_Application.Features.OrganizationType.Commands.UpdateOrganizationType
{
    public class UpdateOrganizationTypeCommand:IRequest<Response<Guid>>
    {
        public Guid Id { get; set; }
        public string? Name { get; set; }
    }

    public class UpdateOrganizationTypeCommandHandler(IOrganizationTypeRepository organizationType, IOrganizationTypevalidator organizationTypevalidator) : IRequestHandler<UpdateOrganizationTypeCommand, Response<Guid>>
    {
        private readonly IOrganizationTypeRepository _organizationType=organizationType;
        private readonly IOrganizationTypevalidator _organizationTypevalidator=organizationTypevalidator;
        public async Task<Response<Guid>> Handle(UpdateOrganizationTypeCommand request, CancellationToken cancellationToken)
        {
            var orgType = await _organizationType.GetByIdOrganizationTypeAsync(request.Id)
                ?? throw new NotFoundException(nameof(OrganizationType), request.Id);

            var orgTypeData = new Organization_Domain.Entities.OrganizationType()
            {
                Id = request.Id,
                Name = request.Name,
                ModifiedBy = "system",
                ModifiedDate = DateTime.Now,
                IsActive = true
            };

             _organizationTypevalidator.ValidateEntity(orgTypeData);
            await _organizationType.UpdateOrganizationTypeAsync(orgTypeData);
            return new Response<Guid>(request.Id,message: Message.organizationTypeUpdate);
                
        }
    }
}
