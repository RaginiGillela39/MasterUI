namespace TQMS_Admin_Application.Features.ExecutiveWindowCategory.Queries.GetAllExecutiveWindowCategory
{
    public class GetAllExecutiveWindowCategoryQuery : IRequest<IEnumerable<TQMS_Admin_Domain.Entities.ExecutiveWindowCategory>>
    {
    }

    public class GetAllExecutiveWindowCategoryQueryHandler(IExecWinCategoryRepository ExecutiveWindowCategoryRepo) : IRequestHandler<GetAllExecutiveWindowCategoryQuery, IEnumerable<TQMS_Admin_Domain.Entities.ExecutiveWindowCategory>>
    {
        private readonly IExecWinCategoryRepository _ExecutiveWindowCategoryRepo = ExecutiveWindowCategoryRepo;

        public async Task<IEnumerable<TQMS_Admin_Domain.Entities.ExecutiveWindowCategory>> Handle(GetAllExecutiveWindowCategoryQuery request, CancellationToken cancellationToken)
        {
            return await _ExecutiveWindowCategoryRepo.GetAllExecutiveWindowCategorysAsync();
        }
    }
}
