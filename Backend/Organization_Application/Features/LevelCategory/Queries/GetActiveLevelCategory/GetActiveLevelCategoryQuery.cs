namespace TQMS_Admin_Application.Features.LevelCategory.Queries.GetActiveLevelCategory
{
    public class GetActiveLevelCategoryQuery : IRequest<Response<IEnumerable<TQMS_Admin_Domain.Entities.LevelCategory>>>
    {
    }

    public class GetActiveLevelCategoryQueryHandler(ILevelCategoryRepository LevelCategoryRepo) : IRequestHandler<GetActiveLevelCategoryQuery, Response<IEnumerable<TQMS_Admin_Domain.Entities.LevelCategory>>>
    {
        private readonly ILevelCategoryRepository _LevelCategoryRepo = LevelCategoryRepo;
        public async Task<Response<IEnumerable<TQMS_Admin_Domain.Entities.LevelCategory>>> Handle(GetActiveLevelCategoryQuery request, CancellationToken cancellationToken)
        {
            var activeLevelCategory = await _LevelCategoryRepo.GetActiveLevelCategoryAsync();
            return new Response<IEnumerable<TQMS_Admin_Domain.Entities.LevelCategory>>(activeLevelCategory);
        }
    }
}
