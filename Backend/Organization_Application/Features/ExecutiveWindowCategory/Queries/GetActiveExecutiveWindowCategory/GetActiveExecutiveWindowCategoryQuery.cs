namespace TQMS_Admin_Application.Features.ExecutiveWindowCategory.Queries.GetActiveExecutiveWindowCategory
{
    public class GetActiveExecutiveWindowCategoryQuery : IRequest<Response<IEnumerable<TQMS_Admin_Domain.Entities.ExecutiveWindowCategory>>>
    {
    }

    public class GetActiveExecutiveWindowCategoryQueryHandler(IExecWinCategoryRepository ExecutiveWindowCategoryRepo) : IRequestHandler<GetActiveExecutiveWindowCategoryQuery, Response<IEnumerable<TQMS_Admin_Domain.Entities.ExecutiveWindowCategory>>>
    {
        private readonly IExecWinCategoryRepository _ExecutiveWindowCategoryRepo = ExecutiveWindowCategoryRepo;
        public async Task<Response<IEnumerable<TQMS_Admin_Domain.Entities.ExecutiveWindowCategory>>> Handle(GetActiveExecutiveWindowCategoryQuery request, CancellationToken cancellationToken)
        {
            var activeExecutiveWindowCategory = await _ExecutiveWindowCategoryRepo.GetActiveExecutiveWindowCategoryAsync();
            return new Response<IEnumerable<TQMS_Admin_Domain.Entities.ExecutiveWindowCategory>>(activeExecutiveWindowCategory);
        }
    }
}
