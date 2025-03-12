namespace TQMS_Admin_Application.Features.Levels.Commands.Updatelevels
{
    public class UpdateLevelsCommand : IRequest<Response<Guid>>
    {
        public Guid Id { get; set; }
        public string? Name { get; set; }
        public string? Acronym { get; set; }
        public Guid Organization_Id { get; set; }
        public Guid Department_Id { get; set; }
        public Guid Branch_Id { get; set; }
        public string? LatestTokenNumber { get; set; }
    }

    public class UpdateLevelsCommandHandler(ILevelsRepository levels,
        IOrganizationRepository organizationRepository,
        IDepartmentRepository departmentRepository,
        IBranchRepository branchRepository,
        ILevelsValidator levelsValidator) : IRequestHandler<UpdateLevelsCommand, Response<Guid>>
    {
        private readonly ILevelsRepository _levels = levels;
        private readonly ILevelsValidator _levelsValidator = levelsValidator;
        private readonly IOrganizationRepository _organizationRepository = organizationRepository;
        private readonly IDepartmentRepository _departmentRepository = departmentRepository;
        private readonly IBranchRepository _branchRepository = branchRepository;

        public async Task<Response<Guid>> Handle(UpdateLevelsCommand request, CancellationToken cancellationToken)
        {
            var organization = await _organizationRepository.GetByIdOrganizationAsync(request.Organization_Id);
            if (organization == null)
                return new Response<Guid>(request.Organization_Id, message: Message.organizationNotFound);
            var department = await _departmentRepository.GetByIdDepartmentAsync(request.Department_Id);
            if (department == null)
                return new Response<Guid>(request.Department_Id, message: Message.departmentNotFound);
            var branch = await _branchRepository.GetByIdBranchAsync(request.Branch_Id);
            if (branch == null)
                return new Response<Guid>(request.Branch_Id, message: Message.branchNotFound);
            var LevelsData = new TQMS_Admin_Domain.Entities.Levels()
            {
                Id = request.Id,
                Name = request.Name,
                Acronym = request.Acronym,
                Organization_Id = request.Organization_Id,
                Department_Id = request.Department_Id,
                Branch_Id = request.Branch_Id,
                LatestTokenNumber = request.LatestTokenNumber,
                ModifiedBy = "System",
                ModifiedDate = DateTime.Now,
                IsActive = true
            };

            _levelsValidator.ValidateEntity(LevelsData);
            await _levels.UpdateLevelsAsync(LevelsData);
            return new Response<Guid>(LevelsData.Id, message: Message.levelsUpdate);
        }
    }
}
