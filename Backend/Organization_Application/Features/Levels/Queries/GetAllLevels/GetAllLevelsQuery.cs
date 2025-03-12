namespace TQMS_Admin_Application.Features.Levels.Queries.GetAllLevels
{
    public class GetAllLevelsQuery : IRequest<IEnumerable<TQMS_Admin_Domain.Entities.Levels>>
    {
    }

    public class GetAllLevelsQueryHandler(ILevelsRepository LevelsRepo) : IRequestHandler<GetAllLevelsQuery, IEnumerable<TQMS_Admin_Domain.Entities.Levels>>
    {
        private readonly ILevelsRepository _LevelsRepo = LevelsRepo;

        public async Task<IEnumerable<TQMS_Admin_Domain.Entities.Levels>> Handle(GetAllLevelsQuery request, CancellationToken cancellationToken)
        {
            return await _LevelsRepo.GetAllLevelssAsync();
        }
    }
}
