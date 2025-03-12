namespace TQMS_Admin_Application.Features.LevelHierarchy.Command.DeleteLevelHierarchy
{
    public class DeleteLevelHierarchyCommand : IRequest<Response<Guid>>
    {
        public Guid Id { get; set; }
    }

    public class DeleteLevelHierarchyCommandHandler(ILevelHierarchyRepository levelRepo) : IRequestHandler<DeleteLevelHierarchyCommand, Response<Guid>>
    {
        private readonly ILevelHierarchyRepository _levelRepo = levelRepo;
        public async Task<Response<Guid>> Handle(DeleteLevelHierarchyCommand request, CancellationToken cancellationToken)
        {
            var LevelHierarchy = await _levelRepo.GetByIdLevelHierarchyAsync(request.Id);
            if (LevelHierarchy == null)
            {
                return new Response<Guid>(request.Id, message: Message.levelHierarchyNotFound);
            }
            LevelHierarchy.IsActive = false;
            LevelHierarchy.ModifiedDate = DateTime.UtcNow;
            LevelHierarchy.ModifiedBy = "System";
            await _levelRepo.DeleteLevelHierarchyAsync(LevelHierarchy);
            return new Response<Guid>(LevelHierarchy.Id, message: Message.levelHierarchyDelete);
        }
    }
}
