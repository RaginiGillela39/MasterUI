namespace TQMS_Admin_Persistence.Repositories
{
    public class ExecutiveWindowCategoryRepository(OrganizationDBContext context) : BaseRepository<ExecutiveWindowCategory>(context), IExecWinCategoryRepository
    {
        public async Task<Guid> AddExecutiveWindowCategoryAsync(ExecutiveWindowCategory ExecutiveWindowCategory)
        {
            await AddAsync(ExecutiveWindowCategory);
            await SaveChanges();
            return ExecutiveWindowCategory.Id;
        }

        public async Task DeleteExecutiveWindowCategoryAsync(ExecutiveWindowCategory ExecutiveWindowCategory)
        {
            await DeleteByIdAsync(ExecutiveWindowCategory.Id);
            await SaveChanges();
        }

        public async Task<IEnumerable<ExecutiveWindowCategory>> GetActiveExecutiveWindowCategoryAsync()
        {
            return await GetFilteredListAsync(o => o.IsActive == true);
        }

        public async Task<IEnumerable<ExecutiveWindowCategory>> GetAllExecutiveWindowCategorysAsync()
        {
            return await GetAllAsync();
        }

        public async Task<ExecutiveWindowCategory> GetByIdExecutiveWindowCategoryAsync(Guid ExecutiveWindowCategoryTypeId)
        {
            return await GetFirstOrDefaultAsync(o => o.Id == ExecutiveWindowCategoryTypeId, o =>
                                                new ExecutiveWindowCategory
                                                {
                                                    Id = o.Id,
                                                    Name = o.Name,
                                                    LevelCategory_Id = o.LevelCategory_Id,
                                                    ExecutiveWindow_Id = o.ExecutiveWindow_Id,
                                                    CreatedBy = o.CreatedBy,
                                                    CreatedDate = o.CreatedDate,
                                                    ModifiedBy = o.ModifiedBy,
                                                    ModifiedDate = o.ModifiedDate,
                                                    IsActive = o.IsActive,
                                                });
        }

        public async Task UpdateExecutiveWindowCategoryAsync(ExecutiveWindowCategory ExecutiveWindowCategory)
        {
            UpdateAsync(ExecutiveWindowCategory);
            await SaveChanges();
        }
    }
}
