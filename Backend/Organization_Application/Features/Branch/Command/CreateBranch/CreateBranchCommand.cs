namespace TQMS_Branch_Application.Features.Branch.Command.CreateBranch
{
    public class CreateBranchCommand:IRequest<Response<Guid>>
    {
        public Guid Id { get; set; }
        public string? Name { get; set; }
        public Guid Org_Id { get; set; }
    }

    public class CreateBranchCommandHandler(IBranchRepository Branch, 
        IOrganizationRepository organizationRepository,
        IBranchValidator BranchValidator) : IRequestHandler<CreateBranchCommand, Response<Guid>>
    {
        private readonly IBranchRepository _Branch = Branch;
        private readonly IBranchValidator _BranchValidator = BranchValidator;
        private readonly IOrganizationRepository _organizationRepository=organizationRepository;
        
        public async Task<Response<Guid>> Handle(CreateBranchCommand request, CancellationToken cancellationToken)
        {
            var organization= _organizationRepository.GetByIdOrganizationAsync(request.Org_Id);
            if (organization == null) 
                return new Response<Guid>(request.Org_Id,message:Message.organizationNotFound);
            var Branch = new Organization_Domain.Entities.Branch()
            {
                Id = Guid.NewGuid(),
                Name = request.Name,
                Org_Id = request.Org_Id,
                CreatedBy = "System",
                CreatedDate = DateTime.Now,
                IsActive = true
            };

            _BranchValidator.ValidateEntity(Branch);
            await _Branch.AddBranchAsync(Branch);
            return new Response<Guid>(Branch.Id, message: Message.branchCreate);

        }
    }
}
