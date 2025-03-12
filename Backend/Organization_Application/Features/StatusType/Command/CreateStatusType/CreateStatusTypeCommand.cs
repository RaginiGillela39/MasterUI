namespace TQMS_Admin_Application.Features.StatusType.Command.CreateStatusType
{
    public class CreateStatusTypeCommand:IRequest<Response<Guid>>
    {
    }

public class CreateStatusTypeCommandHandler(IStatusTypeRepository StatusType,
    IStatusTypeValidator StatusTypeValidator) : IRequestHandler<CreateStatusTypeCommand, Response<Guid>>
{
    private readonly IStatusTypeRepository _StatusType = StatusType;
    private readonly IStatusTypeValidator _StatusTypeValidator = StatusTypeValidator;

    public async Task<Response<Guid>> Handle(CreateStatusTypeCommand request, CancellationToken cancellationToken)
    {
        var StatusType = new TQMS_Admin_Domain.Entities.StatusType()
        {
            Id = Guid.NewGuid(),
            CreatedBy = "System",
            CreatedDate = DateTime.Now,
            IsActive = true
        };

        _StatusTypeValidator.ValidateEntity(StatusType);
        await _StatusType.AddStatusTypeAsync(StatusType);
        return new Response<Guid>(StatusType.Id, message: Message.statusTypeCreate);

    }
}
}
