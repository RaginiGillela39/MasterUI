using TQMS_Organization_Application.Features.Organization.Queries.GetAllOrganization;

namespace TQMS_Organization_Application.Features.Department.Queries.GetAllDepartment
{
    public class GetAllDepartmentQuery:IRequest<IEnumerable<Organization_Domain.Entities.Department>>
    {
    }
    public class GetAllOrganizationQueryHandler(IDepartmentRepository departmentRepo) : IRequestHandler<GetAllDepartmentQuery, IEnumerable<Organization_Domain.Entities.Department>>
    {
        private readonly IDepartmentRepository _departmentRepo = departmentRepo;

        public async Task<IEnumerable<Organization_Domain.Entities.Department>> Handle(GetAllDepartmentQuery request, CancellationToken cancellationToken)
        {
            return await _departmentRepo.GetAllDepartmentsAsync();
        }
    }
}
