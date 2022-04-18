using E02.EFCoreApp.Application.CQRS.Commands;
using E02.EFCoreApp.Data.Context;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace E02.EFCoreApp.Application.CQRS.CommandHandlers
{
    public class UpdateCourseCommandHandler : IRequestHandler<UpdateCourseCommand>
    {
        private readonly YazilimKoyuContext _context;

        public UpdateCourseCommandHandler(YazilimKoyuContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(UpdateCourseCommand request, CancellationToken cancellationToken)
        {
            var updatedCourse = await _context.Courses.SingleOrDefaultAsync(x => x.Id == request.Id);
            if (updatedCourse != null)
            {
                updatedCourse.Title=request.Title; 
                updatedCourse.TeacherId = request.TeacherId;
                await _context.SaveChangesAsync();
            }

            return Unit.Value;
        }
    }
}
