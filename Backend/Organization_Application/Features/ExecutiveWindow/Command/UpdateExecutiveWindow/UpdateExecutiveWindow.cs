namespace TQMS_Admin_Application.Features.ExecutiveWindow.Command.UpdateExecutiveWindow
{
    public class UpdateExecutiveWindowCommand : IRequest<Response<Guid>>
    {
        public Guid Id { get; set; }
        public Guid Level_Id { get; set; }
        public Guid StatusType_Id { get; set; }
    }

    public class UpdateExecutiveWindowCommandHandler(IExecutiveWindowRepository ExecutiveWindow,
        ILevelsRepository levelsRepository,
        IStatusTypeRepository statusTypeRepository,
        IExecutiveWindowValidator ExecutiveWindowValidator) : IRequestHandler<UpdateExecutiveWindowCommand, Response<Guid>>
    {
        private readonly IExecutiveWindowRepository _ExecutiveWindow = ExecutiveWindow;
        private readonly IExecutiveWindowValidator _ExecutiveWindowValidator = ExecutiveWindowValidator;
        private readonly ILevelsRepository _levelsRepository = levelsRepository;
        private readonly IStatusTypeRepository _statusTypeRepository = statusTypeRepository;


        public async Task<Response<Guid>> Handle(UpdateExecutiveWindowCommand request, CancellationToken cancellationToken)
        {
            var levels = await _levelsRepository.GetByIdLevelsAsync(request.Level_Id);
            if (levels == null)
                return new Response<Guid>(request.Level_Id, message: Message.levelsNotFound);
            var statusType = await _statusTypeRepository.GetByIdStatusTypeAsync(request.StatusType_Id);
            if (statusType == null)
                return new Response<Guid>(request.Level_Id, message: Message.statusTypeNotFound);

            var ExecutiveWindow = new TQMS_Admin_Domain.Entities.ExecutiveWindow()
            {
                Id = Guid.NewGuid(),
                Level_Id = request.Level_Id,
                StatusType_Id = request.StatusType_Id,
                ModifiedBy = "System",
                ModifiedDate = DateTime.Now,
                IsActive = true
            };

            _ExecutiveWindowValidator.ValidateEntity(ExecutiveWindow);
            await _ExecutiveWindow.UpdateExecutiveWindowAsync(ExecutiveWindow);
            return new Response<Guid>(ExecutiveWindow.Id, message: Message.executiveWindowCreate);
        }
    }
}
