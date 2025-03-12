namespace TQMS_Admin_Application.Features.ExecutiveWindow.Command.DeleteExecutiveWindow
{
    public class DeleteExecutiveWindowCommand : IRequest<Response<Guid>>
    {
        public Guid Id { get; set; }
    }

    public class DeleteExecutiveWindowCommandHandler(IExecutiveWindowRepository levelRepo) : IRequestHandler<DeleteExecutiveWindowCommand, Response<Guid>>
    {
        private readonly IExecutiveWindowRepository _levelRepo = levelRepo;
        public async Task<Response<Guid>> Handle(DeleteExecutiveWindowCommand request, CancellationToken cancellationToken)
        {
            var ExecutiveWindow = await _levelRepo.GetByIdExecutiveWindowAsync(request.Id);
            if (ExecutiveWindow == null)
            {
                return new Response<Guid>(request.Id, message: Message.executiveWindowNotFound);
            }
            ExecutiveWindow.IsActive = false;
            ExecutiveWindow.ModifiedDate = DateTime.UtcNow;
            ExecutiveWindow.ModifiedBy = "System";
            await _levelRepo.DeleteExecutiveWindowAsync(ExecutiveWindow);
            return new Response<Guid>(ExecutiveWindow.Id, message: Message.executiveWindowDelete);
        }
    }
}
