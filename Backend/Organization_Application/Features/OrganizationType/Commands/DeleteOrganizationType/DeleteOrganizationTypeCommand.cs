
namespace TQMS_Organization_Application.Features.OrganizationType.Commands.DeleteOrganizationType
{
    public class DeleteOrganizationTypeCommand:IRequest<Response<Guid>>
    {
        public Guid Id { get; set; }
    }

    public class DeleteOrganizationTypeCommandHandler(IOrganizationTypeRepository organizationType) : IRequestHandler<DeleteOrganizationTypeCommand, Response<Guid>>
    {
        private readonly IOrganizationTypeRepository _organizationType=organizationType;
        public async Task<Response<Guid>> Handle(DeleteOrganizationTypeCommand request, CancellationToken cancellationToken)
        {
            var organizationData= await _organizationType.GetByIdOrganizationTypeAsync(request.Id);
                if (organizationData == null)
                { 
                    return new Response<Guid>(request.Id,message: Message.organizationTypeNotFound);
                }
                organizationData.IsActive=false;
                organizationData.ModifiedDate=DateTime.UtcNow;
                organizationData.ModifiedBy = "system";
            await _organizationType.DeleteOrganizationTypeAsync(organizationData);
            return new Response<Guid>(request.Id,message: Message.organizationTypeDelete);
        }
    }
}
