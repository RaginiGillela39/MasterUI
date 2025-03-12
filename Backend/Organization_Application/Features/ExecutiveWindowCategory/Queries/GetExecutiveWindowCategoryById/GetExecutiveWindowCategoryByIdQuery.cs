namespace TQMS_Admin_Application.Features.ExecutiveWindowCategory.Queries.GetExecutiveWindowCategoryById
{
    public class GetExecutiveWindowCategoryByIdQuery : IRequest<Response<TQMS_Admin_Domain.Entities.ExecutiveWindowCategory>>
    {
        public Guid Id { get; set; }
    }

    public class GetExecutiveWindowCategoryByIdQueryHandler(IExecWinCategoryRepository ExecutiveWindowCategoryRepo) : IRequestHandler<GetExecutiveWindowCategoryByIdQuery, Response<TQMS_Admin_Domain.Entities.ExecutiveWindowCategory>>
    {
        private readonly IExecWinCategoryRepository _ExecutiveWindowCategoryRepo = ExecutiveWindowCategoryRepo;
        public async Task<Response<TQMS_Admin_Domain.Entities.ExecutiveWindowCategory>> Handle(GetExecutiveWindowCategoryByIdQuery request, CancellationToken cancellationToken)
        {
            var ExecutiveWindowCategory = await _ExecutiveWindowCategoryRepo.GetByIdExecutiveWindowCategoryAsync(request.Id);
            return new Response<TQMS_Admin_Domain.Entities.ExecutiveWindowCategory>(ExecutiveWindowCategory);

        }
    }
}
