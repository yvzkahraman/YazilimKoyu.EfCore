using E02.EFCoreApp.Application.CQRS.Commands;
using E02.EFCoreApp.Data.Context;
using E02.EFCoreApp.Data.Entities;
using MediatR;

namespace E02.EFCoreApp.Application.CQRS.CommandHandlers
{
    public class CreateCourseCommandHandler : IRequestHandler<CreateCourseCommand>
    {
        private readonly YazilimKoyuContext _context;

        public CreateCourseCommandHandler(YazilimKoyuContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(CreateCourseCommand request, CancellationToken cancellationToken)
        {
            var createdCourse = new Course();
            createdCourse.Title = request.Title;
            createdCourse.TeacherId = request.TeacherId;
            await _context.Courses.AddAsync(createdCourse);
            await _context.SaveChangesAsync();

            return Unit.Value;
        }
    }
}
