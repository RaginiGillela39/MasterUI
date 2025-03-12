namespace TQMS_Admin_Application.Features.ExecutiveWindow.Command.ReactiveExecutiveWindow
{
    public class ReactiveExecutiveWindowCommand : IRequest<Response<Guid>>
    {
        public Guid Id { get; set; }
    }
    public class ReactiveExecutiveWindowCommandHandler(IExecutiveWindowRepository ExecutiveWindowRepo) : IRequestHandler<ReactiveExecutiveWindowCommand, Response<Guid>>
    {
        private readonly IExecutiveWindowRepository _ExecutiveWindowRepo = ExecutiveWindowRepo;
        public async Task<Response<Guid>> Handle(ReactiveExecutiveWindowCommand request, CancellationToken cancellationToken)
        {
            var ExecutiveWindow = await _ExecutiveWindowRepo.GetByIdExecutiveWindowAsync(request.Id);
            if (ExecutiveWindow == null)
            {
                return new Response<Guid>(message: Message.executiveWindowNotFound);
            }
            if (ExecutiveWindow.IsActive == true)
            {
                return new Response<Guid>(message: Message.executiveWindowExists);
            }
            ExecutiveWindow.IsActive = true;
            ExecutiveWindow.ModifiedBy = "System";
            ExecutiveWindow.ModifiedDate = DateTime.UtcNow;

            await _ExecutiveWindowRepo.UpdateExecutiveWindowAsync(ExecutiveWindow);
            return new Response<Guid>(ExecutiveWindow.Id, message: Message.executiveWindowReactivate);
        }
    }
}
