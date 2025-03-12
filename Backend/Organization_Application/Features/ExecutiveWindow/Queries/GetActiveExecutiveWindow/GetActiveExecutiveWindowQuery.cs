namespace TQMS_Admin_Application.Features.ExecutiveWindow.Queries.GetActiveExecutiveWindow
{
    public class GetActiveExecutiveWindowQuery : IRequest<Response<IEnumerable<TQMS_Admin_Domain.Entities.ExecutiveWindow>>>
    {
    }

    public class GetActiveExecutiveWindowQueryHandler(IExecutiveWindowRepository ExecutiveWindowRepo) : IRequestHandler<GetActiveExecutiveWindowQuery, Response<IEnumerable<TQMS_Admin_Domain.Entities.ExecutiveWindow>>>
    {
        private readonly IExecutiveWindowRepository _ExecutiveWindowRepo = ExecutiveWindowRepo;
        public async Task<Response<IEnumerable<TQMS_Admin_Domain.Entities.ExecutiveWindow>>> Handle(GetActiveExecutiveWindowQuery request, CancellationToken cancellationToken)
        {
            var activeExecutiveWindow = await _ExecutiveWindowRepo.GetActiveExecutiveWindowAsync();
            return new Response<IEnumerable<TQMS_Admin_Domain.Entities.ExecutiveWindow>>(activeExecutiveWindow);
        }
    }
}
