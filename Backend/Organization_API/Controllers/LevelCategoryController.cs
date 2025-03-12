
namespace TQMS_Admin_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LevelCategoryController(IMediator _mediator) : ControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> Create(CreateLevelCategoryCommand createLevelCategoryCommand)
        {
            var Id = await _mediator.Send(createLevelCategoryCommand);
            return Ok(Id);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid id, UpdateLevelCategoryCommand command)
        {
            if (id != command.Id)
            {
                return BadRequest(Message.levelCategoryNotFound);
            }
            var updateCommand = await _mediator.Send(command);
            return Ok(updateCommand);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var command = new DeleteLevelCategoryCommand { Id = id };
            var deleteCommand = await _mediator.Send(command);
            return Ok(deleteCommand);
        }

        [HttpPut("reactive/{id}")]
        public async Task<IActionResult> Reactivate(Guid id)
        {
            var command = new ReactiveLevelCategoryCommand { Id = id };
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
            var LevelCategory = await _mediator.Send(new GetAllLevelCategoryQuery());
            return Ok(LevelCategory);
        }

        [HttpGet("getById")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var LevelCategory = await _mediator.Send(new GetLevelCategoryByIdQuery { Id = id });
            return Ok(LevelCategory);
        }

        [HttpGet("active")]
        public async Task<IActionResult> GetAllActive()
        {
            var activeOrg = await _mediator.Send(new GetActiveLevelCategoryQuery());
            return Ok(activeOrg);
        }
    }
}
