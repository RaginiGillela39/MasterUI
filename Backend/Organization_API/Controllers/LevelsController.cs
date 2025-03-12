

namespace TQMS_Admin_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LevelsController(IMediator _mediator) : ControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> Create(CreateLevelsCommand createLevelsCommand)
        {
            var Id = await _mediator.Send(createLevelsCommand);
            return Ok(Id);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid id, UpdateLevelsCommand command)
        {
            if (id != command.Id)
            {
                return BadRequest(Message.levelsNotFound);
            }
            var updateCommand = await _mediator.Send(command);
            return Ok(updateCommand);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var command = new DeleteLevelsCommand { Id = id };
            var deleteCommand = await _mediator.Send(command);
            return Ok(deleteCommand);
        }

        [HttpPut("reactive/{id}")]
        public async Task<IActionResult> Reactivate(Guid id)
        {
            var command = new ReactiveLevelsCommand { Id = id };
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
            var Levels = await _mediator.Send(new GetAllLevelsQuery());
            return Ok(Levels);
        }

        [HttpGet("getById")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var Levels = await _mediator.Send(new GetLevelsByIdQuery { Id = id });
            return Ok(Levels);
        }

        [HttpGet("active")]
        public async Task<IActionResult> GetAllActive()
        {
            var activeOrg = await _mediator.Send(new GetActiveLevelsQuery());
            return Ok(activeOrg);
        }
    }
}
