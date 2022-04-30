using E02.EFCoreApp.Application.CQRS.Commands;
using E02.EFCoreApp.Application.Enums;
using E02.EFCoreApp.Data.Context;
using E02.EFCoreApp.Data.Entities;
using MediatR;

namespace E02.EFCoreApp.Application.CQRS.CommandHandlers
{
    public class CreateStudentCommandHandler : IRequestHandler<CreateStudentCommand>
    {
        private readonly YazilimKoyuContext _context;

        public CreateStudentCommandHandler(YazilimKoyuContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(CreateStudentCommand request, CancellationToken cancellationToken)
        {
            var createdStudent = new Student();
            createdStudent.Surname = request.Surname;
            createdStudent.Number = request.Number;
            createdStudent.Username = request.Username;
            createdStudent.City = request.City;
            createdStudent.Name = request.Name;
            createdStudent.University = request.University;
            createdStudent.Password = request.Password;
            createdStudent.RoleId = (int)RoleType.Student;

            await _context.Students.AddAsync(createdStudent);
            await _context.SaveChangesAsync();

            return Unit.Value;
        }
    }
}
