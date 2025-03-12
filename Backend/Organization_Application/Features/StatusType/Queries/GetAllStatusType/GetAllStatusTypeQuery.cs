namespace TQMS_Admin_Application.Features.StatusType.Queries.GetAllStatusType
{
    public class GetAllStatusTypeQuery : IRequest<IEnumerable<TQMS_Admin_Domain.Entities.StatusType>>
    {
    }
    public class GetAllStatusTypeQueryHandler(IStatusTypeRepository StatusTypeRepo) : IRequestHandler<GetAllStatusTypeQuery, IEnumerable<TQMS_Admin_Domain.Entities.StatusType>>
    {
        private readonly IStatusTypeRepository _StatusTypeRepo = StatusTypeRepo;

        public async Task<IEnumerable<TQMS_Admin_Domain.Entities.StatusType>> Handle(GetAllStatusTypeQuery request, CancellationToken cancellationToken)
        {
            return await _StatusTypeRepo.GetAllStatusTypesAsync();
        }
    }

}
