using E02.EFCoreApp.Application.CQRS.Commands;
using E02.EFCoreApp.Application.CQRS.Queries;
using E02.EFCoreApp.Application.Dtos;
using E02.EFCoreApp.Data.Context;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace E02.EFCoreApp.Controllers
{
    //[Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class CoursesController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly YazilimKoyuContext _context;

        public CoursesController(IMediator mediator, YazilimKoyuContext context)
        {
            _mediator = mediator;
            _context = context;
        }

        [Authorize(Roles = "Student,Teacher")]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetCourse([FromRoute] int id)
        {
            var userName = User.Claims.SingleOrDefault(x => x.Type == "userName")?.Value;
            var result = await _mediator.Send(new GetCourseByIdQuery(id));
            return Ok(result);
        }

        [Authorize(Roles = "Student,Teacher")]
        [HttpGet]

        public async Task<IActionResult> GetCourses()
        {
            var result = await _mediator.Send(new GetCourseListQuery());
            return Ok(result);
        }

        //[Authorize(Roles = "Teacher")]
        [HttpPut]
        public async Task<IActionResult> UpdateCourse([FromBody] UpdateCourseCommand command)
        {
            await _mediator.Send(command);
            return NoContent();
        }

        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> CreateCourse([FromBody] CreateCourseCommand command)
        {
            var response = await _mediator.Send(command);
            return Created("", response);
        }

        // api/courses/1
        [HttpDelete("{id}")]
        public async Task<IActionResult> RemoveCourse([FromRoute] int id)
        {
            await _mediator.Send(new RemoveCourseCommand(id));
            return NoContent();
        }

        [AllowAnonymous]

        [HttpGet("{courseId}/students")]
        public async Task<IActionResult> GetStudentsByCourseId(int courseId)
        {
            var data = await _mediator.Send(new GetStudentsByCourseIdQuery(courseId));
            return Ok(data);
        }

        [AllowAnonymous]
        [HttpPost("assignStudent")]
        public IActionResult AssignStudent(List<StudentCourseDto> list)
        {
            foreach (var studentCourse in list)
            {
                var checkedStudent = _context.StudentCourses.SingleOrDefault(x => x.CourseId == studentCourse.CourseId && x.StudentId == studentCourse.StudentId);
                if (studentCourse.IsExist)
                {
                    if(checkedStudent== null)
                    {
                        _context.StudentCourses.Add(new Data.Entities.StudentCourse
                        {
                            CourseId = studentCourse.CourseId,
                            StudentId = studentCourse.StudentId,
                        });
                    }
                }
                else
                {
                    if(checkedStudent!= null)
                    {
                        _context.StudentCourses.Remove(checkedStudent);
                    }
                }
            }
            _context.SaveChanges();
            return Ok();
        }

    }
}
