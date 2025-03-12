namespace TQMS_Admin_Application.Features.ExecutiveWindowCategoryCategory.Command.UpdateExecutiveWindowCategoryCategory
{
    public class UpdateExecutiveWindowCategoryCommand : IRequest<Response<Guid>>
    {
        public Guid Id { get; set; }
        public Guid LevelCategory_Id { get; set; }
        public Guid ExecutiveWindow_Id { get; set; }
    }

    public class UpdateExecutiveWindowCategoryCommandHandler(IExecWinCategoryRepository ExecutiveWindowCategory,
         ILevelCategoryRepository levelCategoryRepository,
        IExecutiveWindowRepository executiveWindowRepository,
       IExecWinCategoryValidator ExecutiveWindowCategoryValidator) : IRequestHandler<UpdateExecutiveWindowCategoryCommand, Response<Guid>>
    {
        private readonly IExecWinCategoryRepository _ExecutiveWindowCategory = ExecutiveWindowCategory;
        private readonly IExecWinCategoryValidator _ExecutiveWindowCategoryValidator = ExecutiveWindowCategoryValidator;
        private readonly ILevelCategoryRepository _levelCategoryRepository = levelCategoryRepository;
        private readonly IExecutiveWindowRepository _executiveWindowRepository = executiveWindowRepository;


        public async Task<Response<Guid>> Handle(UpdateExecutiveWindowCategoryCommand request, CancellationToken cancellationToken)
        {
            var levels = await _levelCategoryRepository.GetByIdLevelCategoryAsync(request.LevelCategory_Id);
            if (levels == null)
                return new Response<Guid>(request.LevelCategory_Id, message: Message.levelCategoryNotFound);
            var statusType = await _executiveWindowRepository.GetByIdExecutiveWindowAsync(request.ExecutiveWindow_Id);
            if (statusType == null)
                return new Response<Guid>(request.ExecutiveWindow_Id, message: Message.executiveWindowNotFound);

            var ExecutiveWindowCategory = new TQMS_Admin_Domain.Entities.ExecutiveWindowCategory()
            {
                Id = Guid.NewGuid(),
                LevelCategory_Id = request.LevelCategory_Id,
                ExecutiveWindow_Id = request.ExecutiveWindow_Id,
                ModifiedBy = "System",
                ModifiedDate = DateTime.Now,
                IsActive = true
            };

            _ExecutiveWindowCategoryValidator.ValidateEntity(ExecutiveWindowCategory);
            await _ExecutiveWindowCategory.UpdateExecutiveWindowCategoryAsync(ExecutiveWindowCategory);
            return new Response<Guid>(ExecutiveWindowCategory.Id, message: Message.executiveWindowCategoryCreate);
        }
    }
}
