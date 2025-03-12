namespace TQMS_Admin_Application.Features.LevelHierarchy.Queries.GetLevelHierarchyById
{
    public class GetLevelHierarchyByIdQuery : IRequest<Response<TQMS_Admin_Domain.Entities.LevelHierarchy>>
    {
        public Guid Id { get; set; }
    }

    public class GetLevelHierarchyByIdQueryHandler(ILevelHierarchyRepository LevelHierarchyRepo) : IRequestHandler<GetLevelHierarchyByIdQuery, Response<TQMS_Admin_Domain.Entities.LevelHierarchy>>
    {
        private readonly ILevelHierarchyRepository _LevelHierarchyRepo = LevelHierarchyRepo;
        public async Task<Response<TQMS_Admin_Domain.Entities.LevelHierarchy>> Handle(GetLevelHierarchyByIdQuery request, CancellationToken cancellationToken)
        {
            var LevelHierarchy = await _LevelHierarchyRepo.GetByIdLevelHierarchyAsync(request.Id);
            return new Response<TQMS_Admin_Domain.Entities.LevelHierarchy>(LevelHierarchy);

        }
    }
}
