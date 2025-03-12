namespace TQMS_Admin_Application.Features.Levels.Queries.GetLevelsById
{
    public class GetLevelsByIdQuery : IRequest<Response<TQMS_Admin_Domain.Entities.Levels>>
    {
        public Guid Id { get; set; }
    }

    public class GetLevelsByIdQueryHandler(ILevelsRepository LevelsRepo) : IRequestHandler<GetLevelsByIdQuery, Response<TQMS_Admin_Domain.Entities.Levels>>
    {
        private readonly ILevelsRepository _LevelsRepo = LevelsRepo;
        public async Task<Response<TQMS_Admin_Domain.Entities.Levels>> Handle(GetLevelsByIdQuery request, CancellationToken cancellationToken)
        {
            var Levels = await _LevelsRepo.GetByIdLevelsAsync(request.Id);
            return new Response<TQMS_Admin_Domain.Entities.Levels>(Levels);

        }
    }
}
