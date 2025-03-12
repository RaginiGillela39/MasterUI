namespace TQMS_Admin_Application.Features.StatusType.Queries.GetStatusTypeById
{
    public class GetStatusTypeByIdQuery : IRequest<Response<TQMS_Admin_Domain.Entities.StatusType>>
    {
        public Guid Id { get; set; }
    }
    public class GetStatusTypeByIdQueryHandler(IStatusTypeRepository StatusTypeRepo) : IRequestHandler<GetStatusTypeByIdQuery, Response<TQMS_Admin_Domain.Entities.StatusType>>
    {
        private readonly IStatusTypeRepository _StatusTypeRepo = StatusTypeRepo;
        public async Task<Response<TQMS_Admin_Domain.Entities.StatusType>> Handle(GetStatusTypeByIdQuery request, CancellationToken cancellationToken)
        {
            var StatusType = await _StatusTypeRepo.GetByIdStatusTypeAsync(request.Id);
            return new Response<TQMS_Admin_Domain.Entities.StatusType>(StatusType);

        }
    }
}
