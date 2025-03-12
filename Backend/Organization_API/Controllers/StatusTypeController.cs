

namespace TQMS_Admin_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StatusTypeController(IMediator _mediator) : ControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> Create(CreateStatusTypeCommand createStatusTypeCommand)
        {
            var Id = await _mediator.Send(createStatusTypeCommand);
            return Ok(Id);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid id, UpdateStatusTypeCommand command)
        {
            if (id != command.Id)
            {
                return BadRequest(Message.statusTypeNotFound);
            }
            var updateCommand = await _mediator.Send(command);
            return Ok(updateCommand);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var command = new DeleteStatusTypeCommand { Id = id };
            var deleteCommand = await _mediator.Send(command);
            return Ok(deleteCommand);
        }

        [HttpPut("reactive/{id}")]
        public async Task<IActionResult> Reactivate(Guid id)
        {
            var command = new ReactiveStatusTypeCommand { Id = id };
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
            var StatusType = await _mediator.Send(new GetAllStatusTypeQuery());
            return Ok(StatusType);
        }

        [HttpGet("getById")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var StatusType = await _mediator.Send(new GetStatusTypeByIdQuery { Id = id });
            return Ok(StatusType);
        }

        [HttpGet("active")]
        public async Task<IActionResult> GetAllActive()
        {
            var activeOrg = await _mediator.Send(new GetActiveStatusTypeQuery());
            return Ok(activeOrg);
        }
    }
}
