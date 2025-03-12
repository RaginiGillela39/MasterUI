
using System.Runtime.InteropServices;

namespace TQMS_Organization_Persistence.Repositories
{
    public class BranchRepository(OrganizationDBContext context) : BaseRepository<Branch>(context), IBranchRepository
    {
        public async Task<Guid> AddBranchAsync(Branch Branch)
        {
            await AddAsync(Branch);
            await SaveChanges();
            return Branch.Id;
        }

        public async Task DeleteBranchAsync(Branch Branch)
        {
           await DeleteByIdAsync(Branch.Id);
            await SaveChanges();
        }

        public async Task<IEnumerable<Branch>> GetActiveBranchAsync()
        {
            return await GetFilteredListAsync(o=>o.IsActive==true);
        }

        public async Task<IEnumerable<Branch>> GetAllBranchsAsync()
        {
            return await GetAllAsync();
        }

        public async Task<Branch> GetByIdBranchAsync(Guid BranchTypeId)
        { 
            return await GetFirstOrDefaultAsync(o=>o.Id==BranchTypeId, o=>
                                                new Branch
                                                { Id=o.Id, 
                                                    Name=o.Name, 
                                                    CreatedBy=o.CreatedBy,
                                                    CreatedDate=o.CreatedDate,
                                                    ModifiedBy=o.ModifiedBy,
                                                    ModifiedDate=o.ModifiedDate,
                                                    IsActive=o.IsActive,
                                                });
        }

    //
        public Task UpdateBranchAsync(Branch Branch)
        {
            throw new NotImplementedException();
        }
    }
}
