

namespace Branch_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BranchController(IMediator _mediator) : ControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> Create(CreateBranchCommand createBranchCommand)
        {
            var Id = await _mediator.Send(createBranchCommand);
            return Ok(Id);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid id, UpdateBranchCommand command)
        {
            if (id != command.Id)
            {
                return BadRequest(Message.branchNotFound);
            }
            var updateCommand = await _mediator.Send(command);
            return Ok(updateCommand);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var command = new DeleteBranchCommand { Id = id };
            var deleteCommand = await _mediator.Send(command);
            return Ok(deleteCommand);
        }

        [HttpPut("reactive/{id}")]
        public async Task<IActionResult> Reactivate(Guid id)
        {
            var command = new ReactiveBranchCommand { Id = id };
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
            var Branch = await _mediator.Send(new GetAllBranchQuery());
            return Ok(Branch);
        }

        [HttpGet("getById")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var Branch = await _mediator.Send(new GetBranchByIdQuery { Id = id });
            return Ok(Branch);
        }

        [HttpGet("active")]
        public async Task<IActionResult> GetAllActive()
        {
            var activeOrg = await _mediator.Send(new GetActiveBranchQuery());
            return Ok(activeOrg);
        }
    }
}
