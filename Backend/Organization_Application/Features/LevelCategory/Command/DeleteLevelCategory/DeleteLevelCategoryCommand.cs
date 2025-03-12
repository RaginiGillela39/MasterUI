namespace TQMS_Admin_Application.Features.LevelCategory.Command.DeleteLevelCategory
{
    public class DeleteLevelCategoryCommand : IRequest<Response<Guid>>
    {
        public Guid Id { get; set; }
    }

    public class DeleteLevelCategoryCommandHandler(ILevelCategoryRepository levelRepo) : IRequestHandler<DeleteLevelCategoryCommand, Response<Guid>>
    {
        private readonly ILevelCategoryRepository _levelRepo = levelRepo;
        public async Task<Response<Guid>> Handle(DeleteLevelCategoryCommand request, CancellationToken cancellationToken)
        {
            var LevelCategory = await _levelRepo.GetByIdLevelCategoryAsync(request.Id);
            if (LevelCategory == null)
            {
                return new Response<Guid>(request.Id, message: Message.levelCategoryNotFound);
            }
            LevelCategory.IsActive = false;
            LevelCategory.ModifiedDate = DateTime.UtcNow;
            LevelCategory.ModifiedBy = "System";
            await _levelRepo.DeleteLevelCategoryAsync(LevelCategory);
            return new Response<Guid>(LevelCategory.Id, message: Message.levelCategoryDelete);
        }
    }
}
