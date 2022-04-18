using E02.EFCoreApp.Application.CQRS.Commands;
using E02.EFCoreApp.Data.Context;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace E02.EFCoreApp.Application.CQRS.CommandHandlers
{
    public class RemoveStudentCommandHandler : IRequestHandler<RemoveStudentCommand>
    {
        private readonly YazilimKoyuContext _context;

        public RemoveStudentCommandHandler(YazilimKoyuContext context)
        {
            _context = context;
        }

        public void Handle(RemoveStudentCommand command)
        {
            var removedStudent = _context.Students.SingleOrDefault(x => x.Id == command.Id);
            if (removedStudent != null)
            {
                _context.Students.Remove(removedStudent);
                _context.SaveChanges();
            }

        }

        public async Task<Unit> Handle(RemoveStudentCommand request, CancellationToken cancellationToken)
        {
            var removedStudent = await _context.Students.SingleOrDefaultAsync(x => x.Id == request.Id);
            if (removedStudent != null)
            {
                _context.Students.Remove(removedStudent);
                _context.SaveChanges();
            }

            return Unit.Value;
        }
    }
}
