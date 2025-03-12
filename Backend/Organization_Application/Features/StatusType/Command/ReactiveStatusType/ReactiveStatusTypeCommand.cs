namespace TQMS_Admin_Application.Features.StatusType.Command.ReactiveStatusType
{
    public class ReactiveStatusTypeCommand : IRequest<Response<Guid>>
    {
        public Guid Id { get; set; }
    }
    public class ReactiveStatusTypeCommandHandler(IStatusTypeRepository StatusTypeRepo) : IRequestHandler<ReactiveStatusTypeCommand, Response<Guid>>
    {
        private readonly IStatusTypeRepository _StatusTypeRepo = StatusTypeRepo;
        public async Task<Response<Guid>> Handle(ReactiveStatusTypeCommand request, CancellationToken cancellationToken)
        {
            var StatusType = await _StatusTypeRepo.GetByIdStatusTypeAsync(request.Id);
            if (StatusType == null)
            {
                return new Response<Guid>(message: Message.statusTypeNotFound);
            }
            if (StatusType.IsActive == true)
            {
                return new Response<Guid>(message: Message.statusTypeExists);
            }
            StatusType.IsActive = true;
            StatusType.ModifiedBy = "System";
            StatusType.ModifiedDate = DateTime.UtcNow;

            await _StatusTypeRepo.UpdateStatusTypeAsync(StatusType);
            return new Response<Guid>(StatusType.Id, message: Message.statusTypeActivate);
        }
    }

}
