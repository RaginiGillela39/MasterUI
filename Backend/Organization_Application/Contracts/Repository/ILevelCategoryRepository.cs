namespace TQMS_Admin_Application.Contracts.Repository
{
    public interface ILevelCategoryRepository
    {
        Task<IEnumerable<LevelCategory>> GetAllLevelCategorysAsync();
        Task<LevelCategory> GetByIdLevelCategoryAsync(Guid LevelCategoryTypeId);
        Task<Guid> AddLevelCategoryAsync(LevelCategory LevelCategory);
        Task UpdateLevelCategoryAsync(LevelCategory LevelCategory);
        Task DeleteLevelCategoryAsync(LevelCategory LevelCategory);
        Task<IEnumerable<LevelCategory>> GetActiveLevelCategoryAsync();
    }
}
