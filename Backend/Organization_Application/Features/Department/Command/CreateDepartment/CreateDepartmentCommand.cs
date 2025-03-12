using TQMS_Organization_Application.Contracts.Repository;

namespace TQMS_Department_Application.Features.Department.Command.CreateDepartment
{
    public class CreateDepartmentCommand : IRequest<Response<Guid>>
    {
        public Guid Id { get; set; }
        public string? Name { get; set; }

        public Guid Org_Id { get; set; }

    }
    public class CreateDepartmentCommandHandler(IDepartmentRepository Department,
        IOrganizationRepository organizationRepository,
        IDepartmentValidator DepartmentValidator) : IRequestHandler<CreateDepartmentCommand, Response<Guid>>
    {
        private readonly IDepartmentRepository _Department = Department;
        private readonly IDepartmentValidator _DepartmentValidator = DepartmentValidator;
        private readonly IOrganizationRepository _organizationRepository = organizationRepository;
        public async Task<Response<Guid>> Handle(CreateDepartmentCommand request, CancellationToken cancellationToken)
        {
            var organization = _organizationRepository.GetByIdOrganizationAsync(request.Org_Id);
            if (organization == null)
                return new Response<Guid>(request.Org_Id, message: Message.organizationNotFound);
            var Department = new Organization_Domain.Entities.Department()
            {
                Id = Guid.NewGuid(),
                Name = request.Name,
                Org_Id=request.Org_Id,
                CreatedBy = "System",
                CreatedDate = DateTime.Now,
                IsActive = true
            };

            _DepartmentValidator.ValidateEntity(Department);
            await _Department.AddDepartmentAsync(Department);
            return new Response<Guid>(Department.Id, message: Message.departmentCreate);

        }
    }
}
