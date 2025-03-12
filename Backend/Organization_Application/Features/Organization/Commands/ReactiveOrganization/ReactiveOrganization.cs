
namespace TQMS_Organization_Application.Features.Organization.Commands.ReactiveOrganization
{
    public class ReactiveOrganizationCommand:IRequest<Response<Guid>>
    {
        public Guid Id { get; set; }
    }
    public class ReactiveOrganizationCommandHandler(IOrganizationRepository organizationRepo) : IRequestHandler<ReactiveOrganizationCommand, Response<Guid>>
    {
        private readonly IOrganizationRepository _organizationRepo = organizationRepo;
        public async Task<Response<Guid>> Handle(ReactiveOrganizationCommand request, CancellationToken cancellationToken)
        {
            var organization=await _organizationRepo.GetByIdOrganizationAsync(request.Id);
            if (organization == null)
            {
                return new Response<Guid>(message:Message.organizationNotFound);
            }
            if (organization.IsActive == true)
            {
                return new Response<Guid>(message: Message.organizationExists);
            }
            organization.IsActive = true;
            organization.ModifiedBy = "System";
            organization.ModifiedDate = DateTime.UtcNow;

            await _organizationRepo.UpdateOrganizationAsync(organization);
            return new Response<Guid>(organization.Id,message:Message.organizationReactivate);
        }
    }
}
