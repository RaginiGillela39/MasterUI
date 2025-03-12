namespace TQMS_Admin_Application.Features.LevelHierarchy.Command.ReactiveLevelHierarchy
{
    public class ReactiveLevelHierarchyCommand : IRequest<Response<Guid>>
    {
        public Guid Id { get; set; }
    }
    public class ReactiveLevelHierarchyCommandHandler(ILevelHierarchyRepository LevelHierarchyRepo) : IRequestHandler<ReactiveLevelHierarchyCommand, Response<Guid>>
    {
        private readonly ILevelHierarchyRepository _LevelHierarchyRepo = LevelHierarchyRepo;
        public async Task<Response<Guid>> Handle(ReactiveLevelHierarchyCommand request, CancellationToken cancellationToken)
        {
            var LevelHierarchy = await _LevelHierarchyRepo.GetByIdLevelHierarchyAsync(request.Id);
            if (LevelHierarchy == null)
            {
                return new Response<Guid>(message: Message.levelHierarchyNotFound);
            }
            if (LevelHierarchy.IsActive == true)
            {
                return new Response<Guid>(message: Message.levelHierarchyExists);
            }
            LevelHierarchy.IsActive = true;
            LevelHierarchy.ModifiedBy = "System";
            LevelHierarchy.ModifiedDate = DateTime.UtcNow;

            await _LevelHierarchyRepo.UpdateLevelHierarchyAsync(LevelHierarchy);
            return new Response<Guid>(LevelHierarchy.Id, message: Message.levelHierarchyReactivate);
        }
    }

}
