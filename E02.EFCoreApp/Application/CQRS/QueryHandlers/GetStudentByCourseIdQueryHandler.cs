using E02.EFCoreApp.Application.CQRS.Queries;
using E02.EFCoreApp.Application.Dtos;
using E02.EFCoreApp.Data.Context;
using E02.EFCoreApp.Data.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace E02.EFCoreApp.Application.CQRS.QueryHandlers
{
    public class GetStudentByCourseIdQueryHandler : IRequestHandler<GetStudentsByCourseIdQuery, List<StudentCourseDto>>
    {
        private readonly YazilimKoyuContext _context;

        public GetStudentByCourseIdQueryHandler(YazilimKoyuContext context)
        {
            _context = context;
        }

        public async Task<List<StudentCourseDto>> Handle(GetStudentsByCourseIdQuery request, CancellationToken cancellationToken)
        {
            var allStudents = await _context.Students.AsNoTracking().ToListAsync();
            /* select * from Students join StudentCourses on Students.Id = StudentCourse.StudentId */
            // IQueryable => databasede yorumlanır
            // IEnumerable => ram

            // List<Product> products  products.Where() => bellekte
            // IQueryable<Product> products product.Where()=> database 

            //var query = from students in _context.Students join studentCourse in _context.StudentCourses on students.Id equals studentCourse.StudentId select new { };


            var students = _context.Students.Join(_context.StudentCourses, student => student.Id, studentCourse => studentCourse.StudentId, (student, studentCourse) => new
            {
                student,
                studentCourse
            }).Where(x => x.studentCourse.CourseId == request.CourseId).Select(x => new Student
            {
                Id = x.student.Id,
                Surname= x.student.Surname,
                RoleId=x.student.RoleId,
                Username= x.student.Username,
                Name = x.student.Name,
                Number= x.student.Number
            }).ToList();


            //Student student1 = new Student();
            //student1.Name = "Yavuz";
            //Student student2 = new Student();
            //student2.Name = "Yavuz";


            //student1 eşit midir student2

            // bir şeyleri karşılaştırırken bir şeylerden faydalanır 
            // çoğunlukla bir interface ya da nesne  IEquatable

            List<StudentCourseDto> list = new List<StudentCourseDto>();

            foreach (var student in allStudents)
            {
                StudentCourseDto dto = new StudentCourseDto();
                dto.Fullname = student.Name+ " "+ student.Surname;
                dto.StudentId = student.Id;
                dto.CourseId = request.CourseId;
                dto.IsExist = students.Select(x=>x.Id).Contains(student.Id);
                list.Add(dto);
            }

            return list;
        }
    }
}
