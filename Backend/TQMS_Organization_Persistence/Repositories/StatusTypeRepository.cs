namespace TQMS_Admin_Persistence.Repositories
{
    public class StatusTypeRepository(OrganizationDBContext context) : BaseRepository<StatusType>(context), IStatusTypeRepository
    {
        public async Task<Guid> AddStatusTypeAsync(StatusType StatusType)
        {
            await AddAsync(StatusType);
            await SaveChanges();
            return StatusType.Id;
        }

        public async Task DeleteStatusTypeAsync(StatusType StatusType)
        {
            await DeleteByIdAsync(StatusType.Id);
            await SaveChanges();
        }

        public async Task<IEnumerable<StatusType>> GetActiveStatusTypeAsync()
        {
            return await GetFilteredListAsync(o => o.IsActive == true);
        }

        public async Task<IEnumerable<StatusType>> GetAllStatusTypesAsync()
        {
            return await GetAllAsync();
        }

        public async Task<StatusType> GetByIdStatusTypeAsync(Guid StatusTypeTypeId)
        {
            return await GetFirstOrDefaultAsync(o => o.Id == StatusTypeTypeId, o =>
                                                new StatusType
                                                {
                                                    Id = o.Id,
                                                    Name = o.Name,
                                                    CreatedBy = o.CreatedBy,
                                                    CreatedDate = o.CreatedDate,
                                                    ModifiedBy = o.ModifiedBy,
                                                    ModifiedDate = o.ModifiedDate,
                                                    IsActive = o.IsActive,
                                                });
        }

        public async Task UpdateStatusTypeAsync(StatusType StatusType)
        {
            UpdateAsync(StatusType);
            await SaveChanges();
        }
    }
}
