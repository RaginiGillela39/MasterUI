namespace TQMS_Admin_Persistence.Repositories
{
    public class LevelCategoryRepository(OrganizationDBContext context) : BaseRepository<LevelCategory>(context), ILevelCategoryRepository
    {
        public async Task<Guid> AddLevelCategoryAsync(LevelCategory LevelCategory)
        {
            await AddAsync(LevelCategory);
            await SaveChanges();
            return LevelCategory.Id;
        }

        public async Task DeleteLevelCategoryAsync(LevelCategory LevelCategory)
        {
            await DeleteByIdAsync(LevelCategory.Id);
            await SaveChanges();
        }

        public async Task<IEnumerable<LevelCategory>> GetActiveLevelCategoryAsync()
        {
            return await GetFilteredListAsync(o => o.IsActive == true);
        }

        public async Task<IEnumerable<LevelCategory>> GetAllLevelCategorysAsync()
        {
            return await GetAllAsync();
        }

        public async Task<LevelCategory> GetByIdLevelCategoryAsync(Guid LevelCategoryTypeId)
        {
            return await GetFirstOrDefaultAsync(o => o.Id == LevelCategoryTypeId, o =>
                                                new LevelCategory
                                                {
                                                    Id = o.Id,
                                                    Name = o.Name,
                                                    Acronym = o.Acronym,
                                                    PriorityNumber = o.PriorityNumber,
                                                    Category=o.Category,
                                                    Level_Id=o.Level_Id,
                                                    CreatedBy = o.CreatedBy,
                                                    CreatedDate = o.CreatedDate,
                                                    ModifiedBy = o.ModifiedBy,
                                                    ModifiedDate = o.ModifiedDate,
                                                    IsActive = o.IsActive,
                                                });
        }

        public async Task UpdateLevelCategoryAsync(LevelCategory LevelCategory)
        {
            UpdateAsync(LevelCategory);
            await SaveChanges();
        }
    }
}
