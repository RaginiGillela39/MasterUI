namespace TQMS_Department_Application.Features.Department.Command.UpdateDepartment
{
    public class UpdateDepartmentCommand : IRequest<Response<Guid>>
    {
        public Guid Id { get; set; }
        public string? Name { get; set; }

        public Guid Org_Id { get; set; }
    }
    public class UpdateDepartmentCommandHandler(IDepartmentRepository Department,
        IDepartmentValidator DepartmentValidator,
        IOrganizationRepository organizationRepository) : IRequestHandler<UpdateDepartmentCommand, Response<Guid>>
    {
        private readonly IDepartmentRepository _Department = Department;
        private readonly IDepartmentValidator _DepartmentValidator = DepartmentValidator;
        private readonly IOrganizationRepository _organizationRepository = organizationRepository;
        public async Task<Response<Guid>> Handle(UpdateDepartmentCommand request, CancellationToken cancellationToken)
        {
            var organization = _organizationRepository.GetByIdOrganizationAsync(request.Org_Id);
            if (organization == null)
                return new Response<Guid>(request.Org_Id, message: Message.organizationNotFound);
            var Department = await _Department.GetByIdDepartmentAsync(request.Id);
            if (Department == null)
            {
                return new Response<Guid>(request.Id, message: Message.departmentNotFound);
            }
            var DepartmentData = new Organization_Domain.Entities.Department()
            {
                Id = request.Id,
                Name = request.Name,
                Org_Id = request.Org_Id,
                ModifiedBy = "System",
                ModifiedDate = DateTime.Now,
                IsActive = true
            };

            _DepartmentValidator.ValidateEntity(DepartmentData);
            await _Department.UpdateDepartmentAsync(DepartmentData);
            return new Response<Guid>(Department.Id, message: Message.departmentUpdate);
        }
    }
}
