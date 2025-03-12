
namespace TQMS_Organization_Persistence.Repositories
{
    public class DepartmentRepository(OrganizationDBContext context) : BaseRepository<Organization_Domain.Entities.Department>(context), IDepartmentRepository
    {
        public async Task<Guid> AddDepartmentAsync(Department Department)
        {
            await AddAsync(Department);
            await SaveChanges();
            return Department.Id;
        }

        public async Task DeleteDepartmentAsync(Department Department)
        {
            await DeleteByIdAsync(Department.Id);
            await SaveChanges();
        }

        public async Task<IEnumerable<Department>> GetActiveDepartmentAsync()
        {
           return await GetFilteredListAsync(o=>o.IsActive==true);
        }

        public async Task<IEnumerable<Department>> GetAllDepartmentsAsync()
        {
            return await GetAllAsync();
        }

        public async Task<Department> GetByIdDepartmentAsync(Guid DepartmentTypeId)
        {
            return await GetFirstOrDefaultAsync(o => o.Id == DepartmentTypeId, o =>
                                                new Department
                                                {
                                                    Id = o.Id,
                                                    Name = o.Name,
                                                    CreatedBy = o.CreatedBy,
                                                    CreatedDate = o.CreatedDate,
                                                    ModifiedBy = o.ModifiedBy,
                                                    ModifiedDate = o.ModifiedDate,
                                                    IsActive = o.IsActive
                                                });
        }

        public async Task UpdateDepartmentAsync(Department Department)
        {
            UpdateAsync(Department);
            await SaveChanges();
        }
    }
}
