namespace TQMS_Admin_Application.Features.Levels.Queries.GetActiveLevels
{
    public class GetActiveLevelsQuery : IRequest<Response<IEnumerable<TQMS_Admin_Domain.Entities.Levels>>>
    {
    }

    public class GetActiveLevelsQueryHandler(ILevelsRepository levelsRepo) : IRequestHandler<GetActiveLevelsQuery, Response<IEnumerable<TQMS_Admin_Domain.Entities.Levels>>>
    {
        private readonly ILevelsRepository _levelsRepo = levelsRepo;
        public async Task<Response<IEnumerable<TQMS_Admin_Domain.Entities.Levels>>> Handle(GetActiveLevelsQuery request, CancellationToken cancellationToken)
        {
            var activeLevels = await _levelsRepo.GetActiveLevelsAsync();
            return new Response<IEnumerable<TQMS_Admin_Domain.Entities.Levels>>(activeLevels);
        }
    }
}
