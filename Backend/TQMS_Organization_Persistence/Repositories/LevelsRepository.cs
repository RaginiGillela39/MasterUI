

namespace TQMS_Admin_Persistence.Repositories
{
    public class LevelsRepository(OrganizationDBContext context) : BaseRepository<Levels>(context),
        ILevelsRepository
    {
        public async Task<Guid> AddLevelsAsync(Levels Levels)
        {
            await AddAsync(Levels);
            await SaveChanges();
            return Levels.Id;
        }

        public async Task DeleteLevelsAsync(Levels Levels)
        {
            await DeleteByIdAsync(Levels.Id);
            await SaveChanges();
        }

        public async Task<IEnumerable<Levels>> GetActiveLevelsAsync()
        {
            return await GetFilteredListAsync(o => o.IsActive == true);
        }

        public async Task<IEnumerable<Levels>> GetAllLevelssAsync()
        {
            return await GetAllAsync();
        }

        public async Task<Levels> GetByIdLevelsAsync(Guid LevelsTypeId)
        {
            return await GetFirstOrDefaultAsync(o => o.Id == LevelsTypeId, o =>
                                                new Levels
                                                {
                                                    Id = o.Id,
                                                    Name = o.Name,
                                                    Acronym = o.Acronym,
                                                    LatestTokenNumber = o.LatestTokenNumber,
                                                    Department_Id=o.Department_Id,
                                                    Organization_Id=o.Organization_Id,  
                                                    Branch_Id=o.Branch_Id,  
                                                    CreatedBy = o.CreatedBy,
                                                    CreatedDate = o.CreatedDate,
                                                    ModifiedBy = o.ModifiedBy,
                                                    ModifiedDate = o.ModifiedDate,
                                                    IsActive = o.IsActive
                                                });
        }

        public async Task UpdateLevelsAsync(Levels Levels)
        {
            UpdateAsync(Levels);
            await SaveChanges();
        }
    }
}
