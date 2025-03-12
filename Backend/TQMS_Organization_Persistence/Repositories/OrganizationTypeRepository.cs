
namespace TQMS_Organization_Persistence.Repositories
{
    public class OrganizationTypeRepository(OrganizationDBContext context) : BaseRepository<OrganizationType>(context), IOrganizationTypeRepository
    {
        public async Task<Guid> AddOrganizationTypeAsync(OrganizationType OrganizationType)
        {
            await AddAsync(OrganizationType);
            await SaveChanges();
            return OrganizationType.Id;
        }

        public async Task DeleteOrganizationTypeAsync(OrganizationType OrganizationType)
        {
            await DeleteByIdAsync(OrganizationType.Id);
            await SaveChanges();
        }

        public async Task<IEnumerable<OrganizationType>> GetActiveOrganizationTypeAsync()
        {
            return await GetFilteredListAsync(o => o.IsActive == true);
        }

        public async Task<IEnumerable<OrganizationType>> GetAllOrganizationTypesAsync()
        {
            return await GetAllAsync();
        }

        public async Task<OrganizationType> GetByIdOrganizationTypeAsync(Guid OrganizationTypeTypeId)
        {
            return await GetFirstOrDefaultAsync(o =>o.Id == OrganizationTypeTypeId,o=>
                                                new OrganizationType
                                                { Id=o.Id,
                                                Name=o.Name,
                                                CreatedBy=o.CreatedBy,
                                                CreatedDate=o.CreatedDate,
                                                ModifiedBy=o.ModifiedBy,
                                                ModifiedDate=o.ModifiedDate,
                                                IsActive=o.IsActive,
                                                });
        }

        public async Task UpdateOrganizationTypeAsync(OrganizationType OrganizationType)
        {
            UpdateAsync(OrganizationType);
            await SaveChanges();
        }
    }
}
