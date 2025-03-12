namespace TQMS_Organization_Application.Contracts.Repository
{
    public interface IDepartmentRepository
    {
        Task<IEnumerable<Department>> GetAllDepartmentsAsync();
        Task<Department> GetByIdDepartmentAsync(Guid DepartmentTypeId);
        Task<Guid> AddDepartmentAsync(Department Department);
        Task UpdateDepartmentAsync(Department Department);
        Task DeleteDepartmentAsync(Department Department);
        Task<IEnumerable<Department>> GetActiveDepartmentAsync();
        //Task<PaginationResponse<Department>> GetPagedDepartmentAsync(int pageNumber, int pageSize);
    }
}
