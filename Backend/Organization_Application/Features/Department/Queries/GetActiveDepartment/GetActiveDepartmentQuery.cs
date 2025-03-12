using TQMS_Department_Application.Features.Department.Queries.GetActiveDepartment;

namespace TQMS_Department_Application.Features.Department.Queries.GetActiveDepartment
{
    public class GetActiveDepartmentQuery:IRequest<Response<IEnumerable<Organization_Domain.Entities.Department>>>
    {
    }
    public class GetActiveDepartmentQueryHandler(IDepartmentRepository DepartmentRepo) : IRequestHandler<GetActiveDepartmentQuery, Response<IEnumerable<Organization_Domain.Entities.Department>>>
    {
        private readonly IDepartmentRepository _DepartmentRepo = DepartmentRepo;
        public async Task<Response<IEnumerable<Organization_Domain.Entities.Department>>> Handle(GetActiveDepartmentQuery request, CancellationToken cancellationToken)
        {
            var activeDepartment = await _DepartmentRepo.GetActiveDepartmentAsync();
            return new Response<IEnumerable<Organization_Domain.Entities.Department>>(activeDepartment);
        }
    }
}
