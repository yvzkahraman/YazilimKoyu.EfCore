﻿using E02.EFCoreApp.Application.CQRS.Commands;
using E02.EFCoreApp.Application.CQRS.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace E02.EFCoreApp.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CoursesController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CoursesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCourse([FromRoute] int id)
        {
            var result = await _mediator.Send(new GetCourseByIdQuery(id));
            return Ok(result);
        }

        [HttpGet]

        public async Task<IActionResult> GetCourses()
        {
            var result = await _mediator.Send(new GetCourseListQuery());
            return Ok(result);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateCourse([FromBody] UpdateCourseCommand command)
        {
            await _mediator.Send(command);
            return NoContent();
        }

        [HttpPost]
        public async Task<IActionResult> CreateCourse([FromBody] CreateCourseCommand command)
        {
            await _mediator.Send(command);
            return Created("", command);
        }

        // api/courses/1
        [HttpDelete("{id}")]
        public async Task<IActionResult> RemoveCourse([FromRoute] int id)
        {
            await _mediator.Send(new RemoveCourseCommand(id));
            return NoContent();
        }

    }
}
