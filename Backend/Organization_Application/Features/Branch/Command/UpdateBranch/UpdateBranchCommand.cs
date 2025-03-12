namespace TQMS_Branch_Application.Features.Branch.Command.UpdateBranch
{
    public class UpdateBranchCommand : IRequest<Response<Guid>>
    {
        public Guid Id { get; set; }
        public string? Name { get; set; }
        public Guid Org_Id {  get; set; }
    }
    public class UpdateBranchCommandHandler(IBranchRepository Branch,
        IBranchValidator BranchValidator,
        IOrganizationRepository organizationRepository) : IRequestHandler<UpdateBranchCommand, Response<Guid>>
    {
        private readonly IBranchRepository _Branch = Branch;
        private readonly IBranchValidator _BranchValidator = BranchValidator;
        private readonly IOrganizationRepository _organizationRepository = organizationRepository;

        public async Task<Response<Guid>> Handle(UpdateBranchCommand request, CancellationToken cancellationToken)
        {
            var organization = _organizationRepository.GetByIdOrganizationAsync(request.Org_Id);
            if (organization == null)
                return new Response<Guid>(request.Org_Id, message: Message.organizationNotFound);
            var Branch = await _Branch.GetByIdBranchAsync(request.Id);
            if (Branch == null)
            {
                return new Response<Guid>(request.Id, message: Message.branchNotFound);
            }
            var BranchData = new Organization_Domain.Entities.Branch()
            {
                Id = request.Id,
                Name = request.Name,
                Org_Id = request.Org_Id,    
                ModifiedBy = "System",
                ModifiedDate = DateTime.Now,
                IsActive = true
            };

            _BranchValidator.ValidateEntity(BranchData);
            await _Branch.UpdateBranchAsync(BranchData);
            return new Response<Guid>(Branch.Id, message: Message.branchUpdate);
        }
    }
}
