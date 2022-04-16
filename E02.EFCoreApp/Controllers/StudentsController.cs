using E02.EFCoreApp.Data.Context;
using E02.EFCoreApp.Data.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace E02.EFCoreApp.Controllers
{
    [ApiController]
    [Route("api/[controller]")]

    // localhost:/api/students
    public class StudentsController : ControllerBase
    {
        private readonly YazilimKoyuContext _context;

        public StudentsController(YazilimKoyuContext context)
        {
            _context = context;
        }

        //api/students
        [HttpGet]
        public IActionResult GetStudents()
        {
            var result= _context.People.AsNoTracking().OfType<Student>().ToList();
            return Ok(result);
        }

        //api/students/yavuz
        [HttpGet("{id}")]
        public IActionResult GetStudentById(int id)
        {
            var student = _context.People.AsNoTracking().OfType<Student>().SingleOrDefault(p => p.Id == id);
            if (student == null)
            {
                return NotFound();
            }
            return Ok(student);
        }

        [HttpPut]
        public IActionResult UpdateStudent()
        {
            var updatedStudent = _context.Students.SingleOrDefault(x=>x.Id == 1);
            updatedStudent.Number = "number değişti";
            _context.SaveChanges();
            return NoContent();
        }


    }
}
