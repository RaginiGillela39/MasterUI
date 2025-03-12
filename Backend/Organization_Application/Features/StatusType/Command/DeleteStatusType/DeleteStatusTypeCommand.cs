namespace TQMS_Admin_Application.Features.StatusType.Command.DeleteStatusType
{
    public class DeleteStatusTypeCommand : IRequest<Response<Guid>>
    {
        public Guid Id { get; set; }
    }
    public class DeleteStatusTypeCommandHandler(IStatusTypeRepository StatusTypeRepo) : IRequestHandler<DeleteStatusTypeCommand, Response<Guid>>
    {
        private readonly IStatusTypeRepository _organizatonRepo = StatusTypeRepo;
        public async Task<Response<Guid>> Handle(DeleteStatusTypeCommand request, CancellationToken cancellationToken)
        {
            var StatusType = await _organizatonRepo.GetByIdStatusTypeAsync(request.Id);
            if (StatusType == null)
            {
                return new Response<Guid>(request.Id, message: Message.statusTypeNotFound);
            }
            StatusType.IsActive = false;
            StatusType.ModifiedDate = DateTime.UtcNow;
            StatusType.ModifiedBy = "System";
            await _organizatonRepo.DeleteStatusTypeAsync(StatusType);
            return new Response<Guid>(StatusType.Id, message: Message.statusTypeDelete);

        }
    }
}
