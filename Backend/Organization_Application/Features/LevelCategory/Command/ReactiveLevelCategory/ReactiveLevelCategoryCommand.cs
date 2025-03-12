namespace TQMS_Admin_Application.Features.LevelCategory.Command.ReactiveLevelCategory
{
    public class ReactiveLevelCategoryCommand : IRequest<Response<Guid>>
    {
        public Guid Id { get; set; }
    }
    public class ReactiveLevelCategoryCommandHandler(ILevelCategoryRepository LevelCategoryRepo) : IRequestHandler<ReactiveLevelCategoryCommand, Response<Guid>>
    {
        private readonly ILevelCategoryRepository _LevelCategoryRepo = LevelCategoryRepo;
        public async Task<Response<Guid>> Handle(ReactiveLevelCategoryCommand request, CancellationToken cancellationToken)
        {
            var LevelCategory = await _LevelCategoryRepo.GetByIdLevelCategoryAsync(request.Id);
            if (LevelCategory == null)
            {
                return new Response<Guid>(message: Message.levelCategoryNotFound);
            }
            if (LevelCategory.IsActive == true)
            {
                return new Response<Guid>(message: Message.levelCategoryExists);
            }
            LevelCategory.IsActive = true;
            LevelCategory.ModifiedBy = "System";
            LevelCategory.ModifiedDate = DateTime.UtcNow;

            await _LevelCategoryRepo.UpdateLevelCategoryAsync(LevelCategory);
            return new Response<Guid>(LevelCategory.Id, message: Message.levelCategoryReactivate);
        }
    }
}
