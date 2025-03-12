namespace TQMS_Admin_Persistence.Repositories
{
    public class ExecutiveWindowRepository(OrganizationDBContext context) : BaseRepository<ExecutiveWindow>(context), IExecutiveWindowRepository
    {
        public async Task<Guid> AddExecutiveWindowAsync(ExecutiveWindow ExecutiveWindow)
        {
            await AddAsync(ExecutiveWindow);
            await SaveChanges();
            return ExecutiveWindow.Id;
        }

        public async Task DeleteExecutiveWindowAsync(ExecutiveWindow ExecutiveWindow)
        {
            await DeleteByIdAsync(ExecutiveWindow.Id);
            await SaveChanges();
        }

        public async Task<IEnumerable<ExecutiveWindow>> GetActiveExecutiveWindowAsync()
        {
            return await GetFilteredListAsync(o => o.IsActive == true);
        }

        public async Task<IEnumerable<ExecutiveWindow>> GetAllExecutiveWindowsAsync()
        {
            return await GetAllAsync();
        }

        public async Task<ExecutiveWindow> GetByIdExecutiveWindowAsync(Guid ExecutiveWindowTypeId)
        {
            return await GetFirstOrDefaultAsync(o => o.Id == ExecutiveWindowTypeId, o =>
                                                new ExecutiveWindow
                                                {
                                                    Id = o.Id,
                                                    Name = o.Name,
                                                    Level_Id = o.Level_Id,
                                                    StatusType_Id = o.StatusType_Id,
                                                    CreatedBy = o.CreatedBy,
                                                    CreatedDate = o.CreatedDate,
                                                    ModifiedBy = o.ModifiedBy,
                                                    ModifiedDate = o.ModifiedDate,
                                                    IsActive = o.IsActive,
                                                });
        }

        public async Task UpdateExecutiveWindowAsync(ExecutiveWindow ExecutiveWindow)
        {
            UpdateAsync(ExecutiveWindow);
            await SaveChanges();
        }
    }
}
