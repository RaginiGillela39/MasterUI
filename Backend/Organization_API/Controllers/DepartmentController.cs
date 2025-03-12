
namespace Organization_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentController(IMediator _mediator) : ControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> Create(CreateDepartmentCommand createDepartmentCommand)
        {
            var Id = await _mediator.Send(createDepartmentCommand);
            return Ok(Id);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid id, UpdateDepartmentCommand command)
        {
            if (id != command.Id)
            {
                return BadRequest(Message.departmentNotFound);
            }
            var updateCommand = await _mediator.Send(command);
            return Ok(updateCommand);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var command = new DeleteDepartmentCommand { Id = id };
            var deleteCommand = await _mediator.Send(command);
            return Ok(deleteCommand);
        }

        [HttpPut("reactive/{id}")]
        public async Task<IActionResult> Reactivate(Guid id)
        {
            var command = new ReactiveDepartmentCommand { Id = id };
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
            var Department = await _mediator.Send(new GetAllDepartmentQuery());
            return Ok(Department);
        }

        [HttpGet("getById")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var Department = await _mediator.Send(new GetDepartmentByIdQuery { Id = id });
            return Ok(Department);
        }

        [HttpGet("active")]
        public async Task<IActionResult> GetAllActive()
        {
            var activeOrg = await _mediator.Send(new GetActiveDepartmentQuery());
            return Ok(activeOrg);
        }
    }
}
