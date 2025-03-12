namespace TQMS_Organization_Application.Contracts.Repository
{
    public interface IOrganizationTypeRepository
    {
        Task<IEnumerable<OrganizationType>> GetAllOrganizationTypesAsync();
        Task<OrganizationType> GetByIdOrganizationTypeAsync(Guid OrganizationTypeTypeId);
        Task<Guid> AddOrganizationTypeAsync(OrganizationType OrganizationType);
        Task UpdateOrganizationTypeAsync(OrganizationType OrganizationType);
        Task DeleteOrganizationTypeAsync(OrganizationType OrganizationType);
        Task<IEnumerable<OrganizationType>> GetActiveOrganizationTypeAsync();
        //Task<PaginationResponse<OrganizationType>> GetPagedOrganizationTypeAsync(int pageNumber, int pageSize);
    }
}
