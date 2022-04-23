using E02.EFCoreApp.Application.CQRS.Commands;
using E02.EFCoreApp.Application.CQRS.Queries;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace E02.EFCoreApp.Controllers
{
    [ApiController]
    [Route("api/[controller]")]

    // localhost:/api/students
    public class StudentsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public StudentsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [Authorize(Roles = "Student")]
        //api/students
        [HttpGet]
        public async Task<IActionResult> GetStudents()
        {
            var result = await _mediator.Send(new GetStudentListQuery());
            return Ok(result);
        }

        //api/students/1
        [HttpGet("{id}")]
        public async Task<IActionResult> GetStudentById([FromRoute] int id)
        {
            var student = await _mediator.Send(new GetStudentByIdQuery(id));
            if (student == null)
            {
                return NotFound();
            }
            return Ok(student);
        }

        //httpput
        //api/students?id=1&name=3242&number 
        // body => student 
        [HttpPut]
        public async Task<IActionResult> UpdateStudent([FromBody] UpdateStudentCommand command)
        {
            await _mediator.Send(command);
            return NoContent();
        }

        // httpdelete
        // api/students/1
        [HttpDelete("{id}")]
        public async Task<IActionResult> RemoveStudent([FromRoute] int id)
        {
            await _mediator.Send(new RemoveStudentCommand(id));
            return NoContent();
        }

        [HttpPost]
        public async Task<IActionResult> CreateStudent([FromBody] CreateStudentCommand command)
        {
            await _mediator.Send(command);
            return Created("", command);
        }


    }
}
