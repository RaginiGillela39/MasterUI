

namespace TQMS_Admin_Application.Contracts.Repository
{
    public interface IExecWinCategoryRepository
    {
        Task<IEnumerable<ExecutiveWindowCategory>> GetAllExecutiveWindowCategorysAsync();
        Task<ExecutiveWindowCategory> GetByIdExecutiveWindowCategoryAsync(Guid ExecutiveWindowCategoryTypeId);
        Task<Guid> AddExecutiveWindowCategoryAsync(ExecutiveWindowCategory ExecutiveWindowCategory);
        Task UpdateExecutiveWindowCategoryAsync(ExecutiveWindowCategory ExecutiveWindowCategory);
        Task DeleteExecutiveWindowCategoryAsync(ExecutiveWindowCategory ExecutiveWindowCategory);
        Task<IEnumerable<ExecutiveWindowCategory>> GetActiveExecutiveWindowCategoryAsync();
    }
}
