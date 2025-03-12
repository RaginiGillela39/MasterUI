using TQMS_Department_Application.Features.Department.Queries.GetDepartmentById;

namespace TQMS_Department_Application.Features.Department.Queries.GetDepartmentById
{
    public class GetDepartmentByIdQuery:IRequest<Response<Organization_Domain.Entities.Department>>
    {
        public Guid Id { get; set; }
    }
    public class GetDepartmentByIdQueryHandler(IDepartmentRepository departmentRepo) : IRequestHandler<GetDepartmentByIdQuery, Response<Organization_Domain.Entities.Department>>
    {
        private readonly IDepartmentRepository _departmentRepo = departmentRepo;
        public async Task<Response<Organization_Domain.Entities.Department>> Handle(GetDepartmentByIdQuery request, CancellationToken cancellationToken)
        {
            var Department = await _departmentRepo.GetByIdDepartmentAsync(request.Id);
            return new Response<Organization_Domain.Entities.Department>(Department);

        }
    }
}
