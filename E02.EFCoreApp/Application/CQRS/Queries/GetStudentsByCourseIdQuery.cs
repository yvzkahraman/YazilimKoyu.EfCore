using E02.EFCoreApp.Application.Dtos;
using MediatR;

namespace E02.EFCoreApp.Application.CQRS.Queries
{
    public class GetStudentsByCourseIdQuery : IRequest<List<StudentCourseDto>>
    {
        public int CourseId { get; set; }

        public GetStudentsByCourseIdQuery(int courseId)
        {
            CourseId = courseId;
        }
    }
}
