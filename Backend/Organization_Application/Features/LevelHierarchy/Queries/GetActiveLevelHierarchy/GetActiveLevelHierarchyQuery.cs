namespace TQMS_Admin_Application.Features.LevelHierarchy.Queries.GetActiveLevelHierarchy
{
    public class GetActiveLevelHierarchyQuery : IRequest<Response<IEnumerable<TQMS_Admin_Domain.Entities.LevelHierarchy>>>
    {
    }

    public class GetActiveLevelHierarchyQueryHandler(ILevelHierarchyRepository LevelHierarchyRepo) : IRequestHandler<GetActiveLevelHierarchyQuery, Response<IEnumerable<TQMS_Admin_Domain.Entities.LevelHierarchy>>>
    {
        private readonly ILevelHierarchyRepository _LevelHierarchyRepo = LevelHierarchyRepo;
        public async Task<Response<IEnumerable<TQMS_Admin_Domain.Entities.LevelHierarchy>>> Handle(GetActiveLevelHierarchyQuery request, CancellationToken cancellationToken)
        {
            var activeLevelHierarchy = await _LevelHierarchyRepo.GetActiveLevelHierarchyAsync();
            return new Response<IEnumerable<TQMS_Admin_Domain.Entities.LevelHierarchy>>(activeLevelHierarchy);
        }
    }
}
