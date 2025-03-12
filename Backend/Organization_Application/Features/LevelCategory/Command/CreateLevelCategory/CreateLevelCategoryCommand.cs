namespace TQMS_Admin_Application.Features.LevelCategory.Command.CreateLevelCategory
{
    public class CreateLevelCategoryCommand : IRequest<Response<Guid>>
    {
        public Guid Id { get; set; }
        public string? Category { get; set; }
        public string? PriorityNumber { get; set; }
        public string? Acronym { get; set; }
        public Guid Level_Id { get; set; }
    }
    public class CreateLevelCategoryCommandHandler(ILevelCategoryRepository levelCategory,
        ILevelsRepository levelsRepository,
        ILevelCategoryValidator levelCategoryValidator) : IRequestHandler<CreateLevelCategoryCommand, Response<Guid>>
    {
        private readonly ILevelCategoryRepository _levelCategory = levelCategory;
        private readonly ILevelCategoryValidator _levelCategoryValidator = levelCategoryValidator;
        private readonly ILevelsRepository _levelsRepository = levelsRepository;


        public async Task<Response<Guid>> Handle(CreateLevelCategoryCommand request, CancellationToken cancellationToken)
        {
            var levels = await _levelsRepository.GetByIdLevelsAsync(request.Level_Id);
            if (levels == null)
                return new Response<Guid>(request.Level_Id, message: Message.branchNotFound);

            var LevelCategory = new TQMS_Admin_Domain.Entities.LevelCategory()
            {
                Id = Guid.NewGuid(),
                Category=request.Category,
                PriorityNumber = request.PriorityNumber,
                Acronym = request.Acronym,
                Level_Id = request.Level_Id,
                CreatedBy = "System",
                CreatedDate = DateTime.Now,
                IsActive = true
            };

            _levelCategoryValidator.ValidateEntity(LevelCategory);
            await _levelCategory.AddLevelCategoryAsync(LevelCategory);
            return new Response<Guid>(LevelCategory.Id, message: Message.levelCategoryCreate);
        }
    }
}
