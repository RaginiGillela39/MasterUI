
namespace TQMS_Admin_Application.Features.LevelCategory.Command.UpdateLevelCategory
{
    public class UpdateLevelCategoryCommand : IRequest<Response<Guid>>
    {
        public Guid Id { get; set; }
        public Guid Level_Id { get; set; }
        public string? Category { get; set; }
        public string? PriorityNumber { get; set; }
        public string? Acronym { get; set; }
    }

    public class CreateLevelCategoryCommandHandler(ILevelCategoryRepository LevelCategory,
       ILevelsRepository levelsRepository,
       ILevelCategoryValidator LevelCategoryValidator) : IRequestHandler<UpdateLevelCategoryCommand, Response<Guid>>
    {
        private readonly ILevelCategoryRepository _LevelCategory = LevelCategory;
        private readonly ILevelCategoryValidator _LevelCategoryValidator = LevelCategoryValidator;
        private readonly ILevelsRepository _levelsRepository = levelsRepository;


        public async Task<Response<Guid>> Handle(UpdateLevelCategoryCommand request, CancellationToken cancellationToken)
        {
            var levels = await _levelsRepository.GetByIdLevelsAsync(request.Level_Id);
            if (levels == null)
                return new Response<Guid>(request.Level_Id, message: Message.branchNotFound);

            var LevelCategory = new TQMS_Admin_Domain.Entities.LevelCategory()
            {
                Id = request.Id,
                Level_Id = levels.Id,
                Category= request.Category,
                PriorityNumber = request.PriorityNumber,
                Acronym = request.Acronym,
                ModifiedBy = "System",
                ModifiedDate = DateTime.Now,
                IsActive = true
            };

            _LevelCategoryValidator.ValidateEntity(LevelCategory);
            await _LevelCategory.AddLevelCategoryAsync(LevelCategory);
            return new Response<Guid>(LevelCategory.Id, message: Message.levelCategoryCreate);
        }
    }
}
