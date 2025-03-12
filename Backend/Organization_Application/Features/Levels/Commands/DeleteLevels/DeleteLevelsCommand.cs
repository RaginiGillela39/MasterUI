namespace TQMS_Admin_Application.Features.Levels.Commands.DeleteLevels
{
    public class DeleteLevelsCommand : IRequest<Response<Guid>>
    {
        public Guid Id { get; set; }
    }

    public class DeleteLevelsCommandHandler(ILevelsRepository levelRepo) : IRequestHandler<DeleteLevelsCommand, Response<Guid>>
    {
        private readonly ILevelsRepository _levelRepo = levelRepo;
        public async Task<Response<Guid>> Handle(DeleteLevelsCommand request, CancellationToken cancellationToken)
        {
            var Levels = await _levelRepo.GetByIdLevelsAsync(request.Id);
            if (Levels == null)
            {
                return new Response<Guid>(request.Id, message: Message.levelsNotFound);
            }
            Levels.IsActive = false;
            Levels.ModifiedDate = DateTime.UtcNow;
            Levels.ModifiedBy = "System";
            await _levelRepo.DeleteLevelsAsync(Levels);
            return new Response<Guid>(Levels.Id, message: Message.levelsDelete);
        }
    }
}

