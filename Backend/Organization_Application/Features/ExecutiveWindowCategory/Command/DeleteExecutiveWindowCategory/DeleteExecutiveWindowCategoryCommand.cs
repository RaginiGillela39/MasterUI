namespace TQMS_Admin_Application.Features.ExecutiveWindowCategory.Command.DeleteExecutiveWindowCategory
{
    public class DeleteExecutiveWindowCategoryCommand : IRequest<Response<Guid>>
    {
        public Guid Id { get; set; }
    }

    public class DeleteExecutiveWindowCategoryCommandHandler(IExecWinCategoryRepository execWinCategoryRepository) : IRequestHandler<DeleteExecutiveWindowCategoryCommand, Response<Guid>>
    {
        private readonly IExecWinCategoryRepository _execWinCategoryRepository = execWinCategoryRepository;
        public async Task<Response<Guid>> Handle(DeleteExecutiveWindowCategoryCommand request, CancellationToken cancellationToken)
        {
            var ExecutiveWindow = await _execWinCategoryRepository.GetByIdExecutiveWindowCategoryAsync(request.Id);
            if (ExecutiveWindow == null)
            {
                return new Response<Guid>(request.Id, message: Message.executiveWindowNotFound);
            }
            ExecutiveWindow.IsActive = false;
            ExecutiveWindow.ModifiedDate = DateTime.UtcNow;
            ExecutiveWindow.ModifiedBy = "System";
            await _execWinCategoryRepository.DeleteExecutiveWindowCategoryAsync(ExecutiveWindow);
            return new Response<Guid>(ExecutiveWindow.Id, message: Message.executiveWindowDelete);
        }
    }
}
