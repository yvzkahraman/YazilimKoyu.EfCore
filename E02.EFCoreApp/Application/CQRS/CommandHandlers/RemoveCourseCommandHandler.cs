using E02.EFCoreApp.Application.CQRS.Commands;
using E02.EFCoreApp.Data.Context;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace E02.EFCoreApp.Application.CQRS.CommandHandlers
{
    public class RemoveCourseCommandHandler : IRequestHandler<RemoveCourseCommand>
    {
        private readonly YazilimKoyuContext _context;

        public RemoveCourseCommandHandler(YazilimKoyuContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(RemoveCourseCommand request, CancellationToken cancellationToken)
        {
            var removedCourse = await _context.Courses.SingleOrDefaultAsync(x => x.Id == request.Id);
            if (removedCourse != null)
            {
                _context.Courses.Remove(removedCourse);
                await _context.SaveChangesAsync();
            }

            return Unit.Value;
        }
    }
}
