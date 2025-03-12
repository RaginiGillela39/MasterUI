namespace TQMS_Organization_Application.Contracts.Repository
{
    public interface IBranchRepository
    {
        Task<IEnumerable<Branch>> GetAllBranchsAsync();
        Task<Branch> GetByIdBranchAsync(Guid BranchTypeId);
        Task<Guid> AddBranchAsync(Branch Branch);
        Task UpdateBranchAsync(Branch Branch);
        Task DeleteBranchAsync(Branch Branch);
        Task<IEnumerable<Branch>> GetActiveBranchAsync();
        //Task<PaginationResponse<Branch>> GetPagedBranchsAsync(int pageNumber, int pageSize);
    }
}
