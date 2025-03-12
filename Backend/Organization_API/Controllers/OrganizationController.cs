namespace Organization_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrganizationController(IMediator _mediator) : ControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> Create(CreateOrganizationCommand createOrganizationCommand)
        {
            var Id = await _mediator.Send(createOrganizationCommand);
            return Ok(Id);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid id, UpdateOrganizationCommand command)
        {
            if (id != command.Id)
            {
                return BadRequest(Message.organizationNotFound);
            }
            var updateCommand = await _mediator.Send(command);
            return Ok(updateCommand);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var command = new DeleteOrganizationCommand { Id = id };
            var deleteCommand = await _mediator.Send(command);
            return Ok(deleteCommand);
        }

        [HttpPut("reactive/{id}")]
        public async Task<IActionResult> Reactivate(Guid id)
        {
            var command = new ReactiveOrganizationCommand { Id = id };
            var result = await _mediator.Send(command);
            if (result.IsSuccess)
            {
                return Ok(new { message = result.Message });
            }
            return BadRequest(new { message = result.Message });
        }

        [HttpGet("getAll")]

        public async Task<IActionResult> GetAll()
        {
            var organization = await _mediator.Send(new GetAllOrganizationQuery());
            return Ok(organization);
        }

        [HttpGet("getById")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var organization = await _mediator.Send(new GetOrganizationByIdQuery { Id = id });
            return Ok(organization);
        }

        [HttpGet("active")]
        public async Task<IActionResult> GetAllActive()
        {
            var activeOrg= await _mediator.Send(new GetActiveOrganizationQuery());
            return Ok(activeOrg);
        }
    }
}
