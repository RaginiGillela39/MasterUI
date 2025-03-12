using TQMS_Admin_Application.Features.LevelHierarchy.Queries.GetAllLevelHierarchy;

namespace TQMS_Admin_Application.Features.LevelHierarchy.Queries.GetAllLevelHierarchy
{
    public class GetAllLevelHierarchyQuery : IRequest<IEnumerable<TQMS_Admin_Domain.Entities.LevelHierarchy>>
    {
    }

    public class GetAllLevelHierarchyQueryHandler(ILevelHierarchyRepository LevelHierarchyRepo) : IRequestHandler<GetAllLevelHierarchyQuery, IEnumerable<TQMS_Admin_Domain.Entities.LevelHierarchy>>
    {
        private readonly ILevelHierarchyRepository _LevelHierarchyRepo = LevelHierarchyRepo;

        public async Task<IEnumerable<TQMS_Admin_Domain.Entities.LevelHierarchy>> Handle(GetAllLevelHierarchyQuery request, CancellationToken cancellationToken)
        {
            return await _LevelHierarchyRepo.GetAllLevelHierarchysAsync();
        }
    }
}
