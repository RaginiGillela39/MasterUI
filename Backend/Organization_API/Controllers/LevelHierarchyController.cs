
namespace TQMS_Admin_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LevelHierarchyController(IMediator _mediator) : ControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> Create(CreateLevelHierarchyCommand createLevelHierarchyCommand)
        {
            var Id = await _mediator.Send(createLevelHierarchyCommand);
            return Ok(Id);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid id, UpdateLevelHierarchyCommand command)
        {
            if (id != command.Id)
            {
                return BadRequest(Message.levelHierarchyNotFound);
            }
            var updateCommand = await _mediator.Send(command);
            return Ok(updateCommand);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var command = new DeleteLevelHierarchyCommand { Id = id };
            var deleteCommand = await _mediator.Send(command);
            return Ok(deleteCommand);
        }

        [HttpPut("reactive/{id}")]
        public async Task<IActionResult> Reactivate(Guid id)
        {
            var command = new ReactiveLevelHierarchyCommand { Id = id };
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
            var LevelHierarchy = await _mediator.Send(new GetAllLevelHierarchyQuery());
            return Ok(LevelHierarchy);
        }

        [HttpGet("getById")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var LevelHierarchy = await _mediator.Send(new GetLevelHierarchyByIdQuery { Id = id });
            return Ok(LevelHierarchy);
        }

        [HttpGet("active")]
        public async Task<IActionResult> GetAllActive()
        {
            var activeOrg = await _mediator.Send(new GetActiveLevelHierarchyQuery());
            return Ok(activeOrg);
        }
    }
}
