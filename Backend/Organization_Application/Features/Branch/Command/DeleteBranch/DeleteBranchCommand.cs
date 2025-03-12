namespace TQMS_Branch_Application.Features.Branch.Command.DeleteBranch
{
    public class DeleteBranchCommand:IRequest<Response<Guid>>
    {
        public Guid Id { get; set; }
    }
    public class DeleteBranchCommandHandler(IBranchRepository branchRepo) : IRequestHandler<DeleteBranchCommand, Response<Guid>>
    {
        private readonly IBranchRepository _organizatonRepo = branchRepo;
        public async Task<Response<Guid>> Handle(DeleteBranchCommand request, CancellationToken cancellationToken)
        {
            var branch = await _organizatonRepo.GetByIdBranchAsync(request.Id);
            if (branch == null)
            {
                return new Response<Guid>(request.Id, message: Message.branchNotFound);
            }
            branch.IsActive = false;
            branch.ModifiedDate = DateTime.UtcNow;
            branch.ModifiedBy = "System";
            await _organizatonRepo.DeleteBranchAsync(branch);
            return new Response<Guid>(branch.Id, message: Message.branchDelete);

        }
    }
}
