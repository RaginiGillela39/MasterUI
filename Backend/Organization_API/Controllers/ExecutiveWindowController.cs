

namespace TQMS_Admin_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExecutiveWindowController(IMediator _mediator) : ControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> Create(CreateExecutiveWindowCommand createExecutiveWindowCommand)
        {
            var Id = await _mediator.Send(createExecutiveWindowCommand);
            return Ok(Id);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid id, UpdateExecutiveWindowCommand command)
        {
            if (id != command.Id)
            {
                return BadRequest(Message.executiveWindowNotFound);
            }
            var updateCommand = await _mediator.Send(command);
            return Ok(updateCommand);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var command = new DeleteExecutiveWindowCommand { Id = id };
            var deleteCommand = await _mediator.Send(command);
            return Ok(deleteCommand);
        }

        [HttpPut("reactive/{id}")]
        public async Task<IActionResult> Reactivate(Guid id)
        {
            var command = new ReactiveExecutiveWindowCommand { Id = id };
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
            var ExecutiveWindow = await _mediator.Send(new GetAllExecutiveWindowQuery());
            return Ok(ExecutiveWindow);
        }

        [HttpGet("getById")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var ExecutiveWindow = await _mediator.Send(new GetExecutiveWindowByIdQuery { Id = id });
            return Ok(ExecutiveWindow);
        }

        [HttpGet("active")]
        public async Task<IActionResult> GetAllActive()
        {
            var activeOrg = await _mediator.Send(new GetActiveExecutiveWindowQuery());
            return Ok(activeOrg);
        }
    }
}
