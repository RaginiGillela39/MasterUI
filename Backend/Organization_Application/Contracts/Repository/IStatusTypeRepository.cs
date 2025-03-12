namespace TQMS_Admin_Application.Contracts.Repository
{
    public interface IStatusTypeRepository
    {
        Task<IEnumerable<StatusType>> GetAllStatusTypesAsync();
        Task<StatusType> GetByIdStatusTypeAsync(Guid StatusTypeTypeId);
        Task<Guid> AddStatusTypeAsync(StatusType StatusType);
        Task UpdateStatusTypeAsync(StatusType StatusType);
        Task DeleteStatusTypeAsync(StatusType StatusType);
        Task<IEnumerable<StatusType>> GetActiveStatusTypeAsync();
    }
}
