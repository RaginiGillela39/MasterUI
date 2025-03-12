namespace TQMS_Organization_Application.Contracts.Repository
{
    public interface IOrganizationRepository
    {
        Task<IEnumerable<Organization>> GetAllOrganizationsAsync();
        Task<Organization> GetByIdOrganizationAsync(Guid OrganizationTypeId);
        Task<Guid> AddOrganizationAsync(Organization Organization);
        Task UpdateOrganizationAsync(Organization Organization);
        Task DeleteOrganizationAsync(Organization Organization);
        Task<IEnumerable<Organization>> GetActiveOrganizationAsync();
        //Task<PaginationResponse<Organization>> GetPagedOrganizationsAsync(int pageNumber, int pageSize);
    }
}

