namespace TQMS_Admin_Application.Features.ExecutiveWindow.Queries.GetAllExecutiveWindow
{
    public class GetAllExecutiveWindowQuery : IRequest<IEnumerable<TQMS_Admin_Domain.Entities.ExecutiveWindow>>
    {
    }

    public class GetAllExecutiveWindowQueryHandler(IExecutiveWindowRepository ExecutiveWindowRepo) : IRequestHandler<GetAllExecutiveWindowQuery, IEnumerable<TQMS_Admin_Domain.Entities.ExecutiveWindow>>
    {
        private readonly IExecutiveWindowRepository _ExecutiveWindowRepo = ExecutiveWindowRepo;

        public async Task<IEnumerable<TQMS_Admin_Domain.Entities.ExecutiveWindow>> Handle(GetAllExecutiveWindowQuery request, CancellationToken cancellationToken)
        {
            return await _ExecutiveWindowRepo.GetAllExecutiveWindowsAsync();
        }
    }
}
