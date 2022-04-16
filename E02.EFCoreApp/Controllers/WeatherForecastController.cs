using E02.EFCoreApp.Data.Context;
using E02.EFCoreApp.Data.Entities;
using Microsoft.AspNetCore.Mvc;

namespace E02.EFCoreApp.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {

        private readonly YazilimKoyuContext _context;
       

        public WeatherForecastController(YazilimKoyuContext context)
        {
            _context = context;
        }

        [HttpPost]
         public IActionResult CreateStudent()
        {
            Student student = new();
            student.Name = "student 1";
            student.Surname = "surname 1";
            student.Number = "234234";
            student.Username = "student";
            student.University = "abc";
            student.City = "Ankara";
            student.Password = "1";

            _context.Students.Add(student);
            _context.SaveChanges();
            return Ok();
        }

        [HttpPost("[action]")]
        public IActionResult CreateTeacher()
        {
            Teacher teacher = new();
            teacher.Name = "student 1";
            teacher.Surname = "surname 1";

            teacher.Username = "student";
            teacher.Profession = "OOP";
            teacher.Password = "1";

            _context.Teachers.Add(teacher);
            _context.SaveChanges();
            return Ok();
        }

    }


    //public class ProductService : IProductService
    //{
    //    public void Update()
    //    {
    //        Console.WriteLine("Ef");
    //    }
    //}

    //public class DpProductService: IProductService
    //{
    //    public void Update()
    //    {
    //        Console.WriteLine("Dapper.Contrib");
    //    }
    //}

    //public interface IProductService
    //{
    //    void Update();
    //}

}