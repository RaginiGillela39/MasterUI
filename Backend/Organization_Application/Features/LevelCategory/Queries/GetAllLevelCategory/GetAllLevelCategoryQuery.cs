namespace TQMS_Admin_Application.Features.LevelCategory.Queries.GetAllLevelCategory
{
    public class GetAllLevelCategoryQuery : IRequest<IEnumerable<TQMS_Admin_Domain.Entities.LevelCategory>>
    {
    }

    public class GetAllLevelCategoryQueryHandler(ILevelCategoryRepository LevelCategoryRepo) : IRequestHandler<GetAllLevelCategoryQuery, IEnumerable<TQMS_Admin_Domain.Entities.LevelCategory>>
    {
        private readonly ILevelCategoryRepository _LevelCategoryRepo = LevelCategoryRepo;

        public async Task<IEnumerable<TQMS_Admin_Domain.Entities.LevelCategory>> Handle(GetAllLevelCategoryQuery request, CancellationToken cancellationToken)
        {
            return await _LevelCategoryRepo.GetAllLevelCategorysAsync();
        }
    }
}
