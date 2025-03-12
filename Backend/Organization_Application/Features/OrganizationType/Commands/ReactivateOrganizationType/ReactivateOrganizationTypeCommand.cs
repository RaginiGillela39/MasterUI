
namespace TQMS_Organization_Application.Features.OrganizationType.Commands.ReactivateOrganizationType
{
    public class ReactivateOrganizationTypeCommand:IRequest<Response<Guid>>
    {
        public Guid Id { get; set; }
    }

    public class ReactivateOrganizationTypeCommandHandler(IOrganizationTypeRepository organizationType) : IRequestHandler<ReactivateOrganizationTypeCommand, Response<Guid>>
    {
        private readonly IOrganizationTypeRepository _organizationType=organizationType;
        public async Task<Response<Guid>> Handle(ReactivateOrganizationTypeCommand request, CancellationToken cancellationToken)
        {
            var orgTypeData= await _organizationType.GetByIdOrganizationTypeAsync(request.Id);
            if (orgTypeData == null)
            {
                return new Response<Guid>(request.Id,message: Message.organizationTypeNotFound);
            }
            if(orgTypeData.IsActive==true)
            {
                return new Response<Guid>(request.Id, message: Message.organizationTypeExists);
            }

            orgTypeData.IsActive = true;
            orgTypeData.ModifiedDate= DateTime.UtcNow;
            orgTypeData.ModifiedBy = "system";

            await _organizationType.UpdateOrganizationTypeAsync(orgTypeData);
            return new Response<Guid>(request.Id, message: Message.organizationTypeActivate);

        }
    }
}
