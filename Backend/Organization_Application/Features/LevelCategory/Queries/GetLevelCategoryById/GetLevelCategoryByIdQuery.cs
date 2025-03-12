namespace TQMS_Admin_Application.Features.LevelCategory.Queries.GetLevelCategoryById
{
    public class GetLevelCategoryByIdQuery : IRequest<Response<TQMS_Admin_Domain.Entities.LevelCategory>>
    {
        public Guid Id { get; set; }
    }

    public class GetLevelCategoryByIdQueryHandler(ILevelCategoryRepository LevelCategoryRepo) : IRequestHandler<GetLevelCategoryByIdQuery, Response<TQMS_Admin_Domain.Entities.LevelCategory>>
    {
        private readonly ILevelCategoryRepository _LevelCategoryRepo = LevelCategoryRepo;
        public async Task<Response<TQMS_Admin_Domain.Entities.LevelCategory>> Handle(GetLevelCategoryByIdQuery request, CancellationToken cancellationToken)
        {
            var LevelCategory = await _LevelCategoryRepo.GetByIdLevelCategoryAsync(request.Id);
            return new Response<TQMS_Admin_Domain.Entities.LevelCategory>(LevelCategory);

        }
    }
}
