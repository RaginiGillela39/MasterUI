namespace TQMS_Department_Application.Features.Department.Command.DeleteDepartment
{
    public class DeleteDepartmentCommand: IRequest<Response<Guid>>
    {
        public Guid Id { get; set; }
    }
    public class DeleteDepartmentCommandHandler(IDepartmentRepository organizatonRepo) : IRequestHandler<DeleteDepartmentCommand, Response<Guid>>
    {
        private readonly IDepartmentRepository _organizatonRepo = organizatonRepo;
        public async Task<Response<Guid>> Handle(DeleteDepartmentCommand request, CancellationToken cancellationToken)
        {
            var Department = await _organizatonRepo.GetByIdDepartmentAsync(request.Id);
            if (Department == null)
            {
                return new Response<Guid>(request.Id, message: Message.departmentNotFound);
            }
            Department.IsActive = false;
            Department.ModifiedDate = DateTime.UtcNow;
            Department.ModifiedBy = "System";
            await _organizatonRepo.DeleteDepartmentAsync(Department);
            return new Response<Guid>(Department.Id, message: Message.departmentDelete);

        }
    }
}
