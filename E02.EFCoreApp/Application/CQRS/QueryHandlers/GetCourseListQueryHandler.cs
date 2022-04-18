using E02.EFCoreApp.Application.CQRS.Queries;
using E02.EFCoreApp.Application.Dtos;
using E02.EFCoreApp.Data.Context;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace E02.EFCoreApp.Application.CQRS.QueryHandlers
{
    public class GetCourseListQueryHandler : IRequestHandler<GetCourseListQuery, List<CourseDto>>
    {
        private readonly YazilimKoyuContext _context;

        public GetCourseListQueryHandler(YazilimKoyuContext context)
        {
            _context = context;
        }

        public async Task<List<CourseDto>> Handle(GetCourseListQuery request, CancellationToken cancellationToken)
        {
            var result = await _context.Courses.AsNoTracking().Select(x => new CourseDto { Id = x.Id, TeacherId = x.TeacherId, Title = x.Title }).ToListAsync();

            return result;
        }
    }
}
