

namespace OrganizationType_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrganizationTypeController(IMediator _mediator) : ControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> Create(CreateOrganizationTypeCommand createOrganizationTypeCommand)
        {
            var Id = await _mediator.Send(createOrganizationTypeCommand);
            return Ok(Id);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid id, UpdateOrganizationTypeCommand command)
        {
            if (id != command.Id)
            {
                return BadRequest(Message.organizationTypeNotFound);
            }
            var updateCommand = await _mediator.Send(command);
            return Ok(updateCommand);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var command = new DeleteOrganizationTypeCommand { Id = id };
            var deleteCommand = await _mediator.Send(command);
            return Ok(deleteCommand);
        }

        [HttpPut("reactive/{id}")]
        public async Task<IActionResult> Reactivate(Guid id)
        {
            var command = new ReactivateOrganizationTypeCommand { Id = id };
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
            var OrganizationType = await _mediator.Send(new GetAllOrganizationTypeQuery());
            return Ok(OrganizationType);
        }

        [HttpGet("getById")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var OrganizationType = await _mediator.Send(new GetOrganizationTypeByIdQuery { Id = id });
            return Ok(OrganizationType);
        }

        [HttpGet("active")]
        public async Task<IActionResult> GetAllActive()
        {
            var activeOrg = await _mediator.Send(new GetAllActiveOrganizationTypeQuery());
            return Ok(activeOrg);
        }
    }
}
