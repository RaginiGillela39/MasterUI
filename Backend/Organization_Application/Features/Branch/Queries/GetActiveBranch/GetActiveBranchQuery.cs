namespace TQMS_Branch_Application.Features.Branch.Queries.GetActiveBranch
{
    public class GetActiveBranchQuery:IRequest<Response<IEnumerable<Organization_Domain.Entities.Branch>>>
    {
    }
    public class GetActiveBranchQueryHandler(IBranchRepository BranchRepo) : IRequestHandler<GetActiveBranchQuery, Response<IEnumerable<Organization_Domain.Entities.Branch>>>
    {
        private readonly IBranchRepository _BranchRepo = BranchRepo;
        public async Task<Response<IEnumerable<Organization_Domain.Entities.Branch>>> Handle(GetActiveBranchQuery request, CancellationToken cancellationToken)
        {
            var activeBranch = await _BranchRepo.GetActiveBranchAsync();
            return new Response<IEnumerable<Organization_Domain.Entities.Branch>>(activeBranch);
        }
    }
}
