using E02.EFCoreApp.Application.CQRS.Queries;
using E02.EFCoreApp.Application.Dtos;
using E02.EFCoreApp.Data.Context;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace E02.EFCoreApp.Application.CQRS.QueryHandlers
{
    public class GetCourseByIdQueryHandler : IRequestHandler<GetCourseByIdQuery, CourseDto?>
    {
        private readonly YazilimKoyuContext _context;

        public GetCourseByIdQueryHandler(YazilimKoyuContext context)
        {
            _context = context;
        }

        public async Task<CourseDto?> Handle(GetCourseByIdQuery request, CancellationToken cancellationToken)
        {
            var result = await _context.Courses.AsNoTracking().Select(x=> new CourseDto
            {
                Id = x.Id,
                TeacherId = x.TeacherId,
                Title= x.Title,
            }).SingleOrDefaultAsync(x=>x.Id==request.Id);
           
            return result;
        }
    }
}
