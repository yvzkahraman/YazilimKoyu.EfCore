using E02.EFCoreApp.Application.CQRS.Commands;
using E02.EFCoreApp.Data.Context;
using E02.EFCoreApp.Data.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace E02.EFCoreApp.Application.CQRS.CommandHandlers
{
    public class RemoveTeacherCommandHandler : IRequestHandler<RemoveTeacherCommand>
    {
        private readonly YazilimKoyuContext _context;

        public RemoveTeacherCommandHandler(YazilimKoyuContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(RemoveTeacherCommand request, CancellationToken cancellationToken)
        {
            var deletedTeacher = await _context.People.OfType<Teacher>().SingleOrDefaultAsync(x => x.Id == request.Id);
            if (deletedTeacher != null)
            {
                _context.Remove(deletedTeacher);
                await _context.SaveChangesAsync();
            }
            return Unit.Value;
        }
    }
}
