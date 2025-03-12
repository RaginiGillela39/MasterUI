namespace TQMS_Admin_Application.Features.StatusType.Queries.GetActiveStatusType
{
    public class GetActiveStatusTypeQuery : IRequest<Response<IEnumerable<TQMS_Admin_Domain.Entities.StatusType>>>
    {
    }
    public class GetActiveStatusTypeQueryHandler(IStatusTypeRepository StatusTypeRepo) : IRequestHandler<GetActiveStatusTypeQuery, Response<IEnumerable<TQMS_Admin_Domain.Entities.StatusType>>>
    {
        private readonly IStatusTypeRepository _StatusTypeRepo = StatusTypeRepo;
        public async Task<Response<IEnumerable<TQMS_Admin_Domain.Entities.StatusType>>> Handle(GetActiveStatusTypeQuery request, CancellationToken cancellationToken)
        {
            var activeStatusType = await _StatusTypeRepo.GetActiveStatusTypeAsync();
            return new Response<IEnumerable<TQMS_Admin_Domain.Entities.StatusType>>(activeStatusType);
        }
    }

}
