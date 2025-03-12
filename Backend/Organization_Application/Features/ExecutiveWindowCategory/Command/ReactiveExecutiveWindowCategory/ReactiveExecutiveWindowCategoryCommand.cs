namespace TQMS_Admin_Application.Features.ExecutiveWindowCategoryCategory.Command.ReactiveExecutiveWindowCategoryCategory
{
    public class ReactiveExecutiveWindowCategoryCommand : IRequest<Response<Guid>>
    {
        public Guid Id { get; set; }
    }
    public class ReactiveExecutiveWindowCategoryCategoryCommandHandler(IExecWinCategoryRepository ExecutiveWindowCategoryRepo) : IRequestHandler<ReactiveExecutiveWindowCategoryCommand, Response<Guid>>
    {
        private readonly IExecWinCategoryRepository _ExecutiveWindowCategoryRepo = ExecutiveWindowCategoryRepo;
        public async Task<Response<Guid>> Handle(ReactiveExecutiveWindowCategoryCommand request, CancellationToken cancellationToken)
        {
            var ExecutiveWindowCategory = await _ExecutiveWindowCategoryRepo.GetByIdExecutiveWindowCategoryAsync(request.Id);
            if (ExecutiveWindowCategory == null)
            {
                return new Response<Guid>(message: Message.executiveWindowCategoryNotFound);
            }
            if (ExecutiveWindowCategory.IsActive == true)
            {
                return new Response<Guid>(message: Message.executiveWindowCategoryExists);
            }
            ExecutiveWindowCategory.IsActive = true;
            ExecutiveWindowCategory.ModifiedBy = "System";
            ExecutiveWindowCategory.ModifiedDate = DateTime.UtcNow;

            await _ExecutiveWindowCategoryRepo.UpdateExecutiveWindowCategoryAsync(ExecutiveWindowCategory);
            return new Response<Guid>(ExecutiveWindowCategory.Id, message: Message.executiveWindowCategoryReactivate);
        }
    }
}
