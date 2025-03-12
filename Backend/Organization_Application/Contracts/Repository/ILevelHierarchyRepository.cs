namespace TQMS_Admin_Application.Contracts.Repository
{
    public interface ILevelHierarchyRepository
    {
        Task<IEnumerable<LevelHierarchy>> GetAllLevelHierarchysAsync();
        Task<LevelHierarchy> GetByIdLevelHierarchyAsync(Guid LevelHierarchyTypeId);
        Task<Guid> AddLevelHierarchyAsync(LevelHierarchy LevelHierarchy);
        Task UpdateLevelHierarchyAsync(LevelHierarchy LevelHierarchy);
        Task DeleteLevelHierarchyAsync(LevelHierarchy LevelHierarchy);
        Task<IEnumerable<LevelHierarchy>> GetActiveLevelHierarchyAsync();
    }
}
