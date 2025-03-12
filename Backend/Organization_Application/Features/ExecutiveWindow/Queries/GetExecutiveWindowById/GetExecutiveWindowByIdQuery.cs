namespace TQMS_Admin_Application.Features.ExecutiveWindow.Queries.GetExecutiveWindowById
{
    public class GetExecutiveWindowByIdQuery : IRequest<Response<TQMS_Admin_Domain.Entities.ExecutiveWindow>>
    {
        public Guid Id { get; set; }
    }

    public class GetExecutiveWindowByIdQueryHandler(IExecutiveWindowRepository ExecutiveWindowRepo) : IRequestHandler<GetExecutiveWindowByIdQuery, Response<TQMS_Admin_Domain.Entities.ExecutiveWindow>>
    {
        private readonly IExecutiveWindowRepository _ExecutiveWindowRepo = ExecutiveWindowRepo;
        public async Task<Response<TQMS_Admin_Domain.Entities.ExecutiveWindow>> Handle(GetExecutiveWindowByIdQuery request, CancellationToken cancellationToken)
        {
            var ExecutiveWindow = await _ExecutiveWindowRepo.GetByIdExecutiveWindowAsync(request.Id);
            return new Response<TQMS_Admin_Domain.Entities.ExecutiveWindow>(ExecutiveWindow);

        }
    }
}
