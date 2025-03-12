
namespace TQMS_Organization_Application.Features.Organization.Commands.DeleteOraganization
{
    public class DeleteOrganizationCommand: IRequest<Response<Guid>>
    {
        public Guid Id { get; set; }
    }

    public class DeleteOrganizationCommandHandler(IOrganizationRepository organizatonRepo) : IRequestHandler<DeleteOrganizationCommand, Response<Guid>>
    {
        private readonly IOrganizationRepository _organizatonRepo=organizatonRepo;
        public async Task<Response<Guid>> Handle(DeleteOrganizationCommand request, CancellationToken cancellationToken)
        { 
            var organization= await _organizatonRepo.GetByIdOrganizationAsync(request.Id);
            if (organization == null)
            {
                return new Response<Guid>(request.Id, message: Message.organizationTypeNotFound);
            }
            organization.IsActive = false;
                organization.ModifiedDate = DateTime.UtcNow;
                organization.ModifiedBy = "System";
            await _organizatonRepo.DeleteOrganizationAsync(organization);
            return new Response<Guid>(organization.Id, message: Message.organizationDelete);

        }
    }
}
