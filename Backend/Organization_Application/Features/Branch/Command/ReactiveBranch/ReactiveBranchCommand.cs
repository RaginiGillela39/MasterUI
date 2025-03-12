namespace TQMS_Branch_Application.Features.Branch.Command.ReactiveBranch
{
    public class ReactiveBranchCommand:IRequest<Response<Guid>>
    {
        public Guid Id { get; set; }
    }
    public class ReactiveBranchCommandHandler(IBranchRepository BranchRepo) : IRequestHandler<ReactiveBranchCommand, Response<Guid>>
    {
        private readonly IBranchRepository _BranchRepo = BranchRepo;
        public async Task<Response<Guid>> Handle(ReactiveBranchCommand request, CancellationToken cancellationToken)
        {
            var Branch = await _BranchRepo.GetByIdBranchAsync(request.Id);
            if (Branch == null)
            {
                return new Response<Guid>(message: Message.branchNotFound);
            }
            if (Branch.IsActive == true)
            {
                return new Response<Guid>(message: Message.branchExists);
            }
            Branch.IsActive = true;
            Branch.ModifiedBy = "System";
            Branch.ModifiedDate = DateTime.UtcNow;

            await _BranchRepo.UpdateBranchAsync(Branch);
            return new Response<Guid>(Branch.Id, message: Message.branchActivate);
        }
    }
}
