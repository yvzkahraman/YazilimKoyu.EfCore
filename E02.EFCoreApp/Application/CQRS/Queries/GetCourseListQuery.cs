using E02.EFCoreApp.Application.Dtos;
using MediatR;

namespace E02.EFCoreApp.Application.CQRS.Queries
{
    public class GetCourseListQuery : IRequest<List<CourseDto>>
    {
    }
}
