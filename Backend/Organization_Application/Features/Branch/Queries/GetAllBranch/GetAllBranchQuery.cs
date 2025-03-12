using TQMS_Branch_Application.Features.Branch.Queries.GetAllBranch;

namespace TQMS_Branch_Application.Features.Branch.Queries.GetAllBranch
{
    public class GetAllBranchQuery:IRequest<IEnumerable<Organization_Domain.Entities.Branch>>
    {
    }
    public class GetAllBranchQueryHandler(IBranchRepository BranchRepo) : IRequestHandler<GetAllBranchQuery, IEnumerable<Organization_Domain.Entities.Branch>>
    {
        private readonly IBranchRepository _BranchRepo = BranchRepo;

        public async Task<IEnumerable<Organization_Domain.Entities.Branch>> Handle(GetAllBranchQuery request, CancellationToken cancellationToken)
        {
            return await _BranchRepo.GetAllBranchsAsync();
        }
    }
}
