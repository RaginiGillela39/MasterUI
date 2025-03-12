namespace TQMS_Admin_Application.Contracts.Repository
{
    public interface IExecutiveWindowRepository
    {
        Task<IEnumerable<ExecutiveWindow>> GetAllExecutiveWindowsAsync();
        Task<ExecutiveWindow> GetByIdExecutiveWindowAsync(Guid ExecutiveWindowTypeId);
        Task<Guid> AddExecutiveWindowAsync(ExecutiveWindow ExecutiveWindow);
        Task UpdateExecutiveWindowAsync(ExecutiveWindow ExecutiveWindow);
        Task DeleteExecutiveWindowAsync(ExecutiveWindow ExecutiveWindow);
        Task<IEnumerable<ExecutiveWindow>> GetActiveExecutiveWindowAsync();
    }
}
