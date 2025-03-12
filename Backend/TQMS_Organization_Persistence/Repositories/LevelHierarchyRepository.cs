namespace TQMS_Admin_Persistence.Repositories
{
    public class LevelHierarchyRepository(OrganizationDBContext context) : BaseRepository<LevelHierarchy>(context), ILevelHierarchyRepository
    {
        public async Task<Guid> AddLevelHierarchyAsync(LevelHierarchy LevelHierarchy)
        {
            await AddAsync(LevelHierarchy);
            await SaveChanges();
            return LevelHierarchy.Id;
        }

        public async Task DeleteLevelHierarchyAsync(LevelHierarchy LevelHierarchy)
        {
            await DeleteByIdAsync(LevelHierarchy.Id);
            await SaveChanges();
        }

        public async Task<IEnumerable<LevelHierarchy>> GetActiveLevelHierarchyAsync()
        {
            return await GetFilteredListAsync(o => o.IsActive == true);
        }

        public async Task<IEnumerable<LevelHierarchy>> GetAllLevelHierarchysAsync()
        {
            return await GetAllAsync();
        }

        public async Task<LevelHierarchy> GetByIdLevelHierarchyAsync(Guid LevelHierarchyTypeId)
        {
            return await GetFirstOrDefaultAsync(o => o.Id == LevelHierarchyTypeId, o =>
                                                new LevelHierarchy
                                                {
                                                    Id = o.Id,
                                                    Name = o.Name,
                                                    Level_Id = o.Level_Id,
                                                    Parent_Id = o.Parent_Id,
                                                    CreatedBy = o.CreatedBy,
                                                    CreatedDate = o.CreatedDate,
                                                    ModifiedBy = o.ModifiedBy,
                                                    ModifiedDate = o.ModifiedDate,
                                                    IsActive = o.IsActive,
                                                });
        }

        public async Task UpdateLevelHierarchyAsync(LevelHierarchy LevelHierarchy)
        {
            UpdateAsync(LevelHierarchy);
            await SaveChanges();
        }
    }
}
