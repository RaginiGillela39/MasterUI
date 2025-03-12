namespace TQMS_Organization_Persistence.Repositories
{
    public class OrganizationRepository(OrganizationDBContext context) : BaseRepository<Organization>(context),
        IOrganizationRepository
    {
        public async Task<Guid> AddOrganizationAsync(Organization Organization)
        {
            await AddAsync(Organization);
            await SaveChanges();
            return Organization.Id;
        }

        public async Task DeleteOrganizationAsync(Organization Organization)
        {
            await DeleteByIdAsync(Organization.Id);
            await SaveChanges();
        }

        public async Task<IEnumerable<Organization>> GetActiveOrganizationAsync()
        {
            return await GetFilteredListAsync(o=>o.IsActive==true); 
        }

        public async Task<IEnumerable<Organization>> GetAllOrganizationsAsync()
        {
            return await GetAllAsync();
        }

        public async Task<Organization> GetByIdOrganizationAsync(Guid OrganizationTypeId)
        {
            return await GetFirstOrDefaultAsync(o=>o.Id==OrganizationTypeId,o=>
                                                new Organization
                                                {
                                                    Id = o.Id,
                                                    Name = o.Name,
                                                    Description = o.Description,
                                                    CreatedBy = o.CreatedBy,
                                                    CreatedDate = o.CreatedDate,
                                                    ModifiedBy = o.ModifiedBy,
                                                    ModifiedDate = o.ModifiedDate,
                                                    IsActive = o.IsActive
                                                });
        }

        public async Task UpdateOrganizationAsync(Organization Organization)
        {
            UpdateAsync(Organization);
            await SaveChanges();
        }
    }
}
