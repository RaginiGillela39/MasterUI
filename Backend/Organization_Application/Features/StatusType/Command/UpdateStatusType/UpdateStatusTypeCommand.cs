namespace TQMS_Admin_Application.Features.StatusType.Command.UpdateStatusType
{
    public class UpdateStatusTypeCommand : IRequest<Response<Guid>>
    {
        public Guid Id { get; set; }
    }
    public class UpdateStatusTypeCommandHandler(IStatusTypeRepository StatusType,
        IStatusTypeValidator StatusTypeValidator) : IRequestHandler<UpdateStatusTypeCommand, Response<Guid>>
    {
        private readonly IStatusTypeRepository _StatusType = StatusType;
        private readonly IStatusTypeValidator _StatusTypeValidator = StatusTypeValidator;

        public async Task<Response<Guid>> Handle(UpdateStatusTypeCommand request, CancellationToken cancellationToken)
        {
            var StatusType = await _StatusType.GetByIdStatusTypeAsync(request.Id);
            if (StatusType == null)
            {
                return new Response<Guid>(request.Id, message: Message.statusTypeNotFound);
            }
            var StatusTypeData = new TQMS_Admin_Domain.Entities.StatusType()
            {
                Id = request.Id,
                ModifiedBy = "System",
                ModifiedDate = DateTime.Now,
                IsActive = true
            };

            _StatusTypeValidator.ValidateEntity(StatusTypeData);
            await _StatusType.UpdateStatusTypeAsync(StatusTypeData);
            return new Response<Guid>(StatusType.Id, message: Message.statusTypeUpdate);
        }
    }

}
