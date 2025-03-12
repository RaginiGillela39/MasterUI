namespace TQMS_Department_Application.Features.Department.Command.ReactiveDepartment
{
    public class ReactiveDepartmentCommand:IRequest<Response<Guid>>
    {
        public Guid Id { get; set; }
    }
    public class ReactiveDepartmentCommandHandler(IDepartmentRepository DepartmentRepo) : IRequestHandler<ReactiveDepartmentCommand, Response<Guid>>
    {
        private readonly IDepartmentRepository _DepartmentRepo = DepartmentRepo;
        public async Task<Response<Guid>> Handle(ReactiveDepartmentCommand request, CancellationToken cancellationToken)
        {
            var Department = await _DepartmentRepo.GetByIdDepartmentAsync(request.Id);
            if (Department == null)
            {
                return new Response<Guid>(message: Message.departmentNotFound);
            }
            if (Department.IsActive == true)
            {
                return new Response<Guid>(message: Message.departmentExists);
            }
            Department.IsActive = true;
            Department.ModifiedBy = "System";
            Department.ModifiedDate = DateTime.UtcNow;

            await _DepartmentRepo.UpdateDepartmentAsync(Department);
            return new Response<Guid>(Department.Id, message: Message.departmentReactivate);
        }
    }
}
