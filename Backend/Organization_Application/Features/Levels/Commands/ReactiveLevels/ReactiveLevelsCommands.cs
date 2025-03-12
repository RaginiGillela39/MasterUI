namespace TQMS_Admin_Application.Features.Levels.Commands.ReactiveLevels
{
    public class ReactiveLevelsCommand : IRequest<Response<Guid>>
    {
        public Guid Id { get; set; }
    }
    public class ReactiveLevelsCommandHandler(ILevelsRepository levelsRepo) : IRequestHandler<ReactiveLevelsCommand, Response<Guid>>
    {
        private readonly ILevelsRepository _levelsRepo = levelsRepo;
        public async Task<Response<Guid>> Handle(ReactiveLevelsCommand request, CancellationToken cancellationToken)
        {
            var Levels = await _levelsRepo.GetByIdLevelsAsync(request.Id);
            if (Levels == null)
            {
                return new Response<Guid>(message: Message.levelsNotFound);
            }
            if (Levels.IsActive == true)
            {
                return new Response<Guid>(message: Message.levelsExists);
            }
            Levels.IsActive = true;
            Levels.ModifiedBy = "System";
            Levels.ModifiedDate = DateTime.UtcNow;

            await _levelsRepo.UpdateLevelsAsync(Levels);
            return new Response<Guid>(Levels.Id, message: Message.levelsReactivate);
        }
    }
}
