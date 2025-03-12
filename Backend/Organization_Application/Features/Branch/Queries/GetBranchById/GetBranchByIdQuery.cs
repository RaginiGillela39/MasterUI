using TQMS_Branch_Application.Features.Branch.Queries.GetBranchById;

namespace TQMS_Branch_Application.Features.Branch.Queries.GetBranchById
{
    public class GetBranchByIdQuery:IRequest<Response<Organization_Domain.Entities.Branch>>
    {
        public Guid Id { get; set; }
    }
    public class GetBranchByIdQueryHandler(IBranchRepository BranchRepo) : IRequestHandler<GetBranchByIdQuery, Response<Organization_Domain.Entities.Branch>>
    {
        private readonly IBranchRepository _BranchRepo = BranchRepo;
        public async Task<Response<Organization_Domain.Entities.Branch>> Handle(GetBranchByIdQuery request, CancellationToken cancellationToken)
        {
            var Branch = await _BranchRepo.GetByIdBranchAsync(request.Id);
            return new Response<Organization_Domain.Entities.Branch>(Branch);

        }
    }
}
