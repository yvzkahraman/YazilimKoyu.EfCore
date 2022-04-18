using E02.EFCoreApp.Application.CQRS.Commands;
using E02.EFCoreApp.Data.Context;
using E02.EFCoreApp.Data.Entities;
using MediatR;

namespace E02.EFCoreApp.Application.CQRS.CommandHandlers
{
    public class CreateTeacherCommandHandler : IRequestHandler<CreateTeacherCommand>
    {
        private readonly YazilimKoyuContext _context;

        public CreateTeacherCommandHandler(YazilimKoyuContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(CreateTeacherCommand request, CancellationToken cancellationToken)
        {
            var createdTeacher = new Teacher
            {
                Surname = request.Surname,
                Username = request.Username,
                Name = request.Name,
                Password = request.Password,
                Profession = request.Profession
            };

            await _context.Teachers.AddAsync(createdTeacher);
            await _context.SaveChangesAsync();

            return Unit.Value;

        }
    }
}
