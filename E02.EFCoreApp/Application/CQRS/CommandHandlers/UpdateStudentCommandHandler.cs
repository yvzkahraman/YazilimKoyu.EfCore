using E02.EFCoreApp.Application.CQRS.Commands;
using E02.EFCoreApp.Data.Context;
using MediatR;

namespace E02.EFCoreApp.Application.CQRS.CommandHandlers
{
    public class UpdateStudentCommandHandler : IRequestHandler<UpdateStudentCommand>
    {
        private readonly YazilimKoyuContext _context;

        public UpdateStudentCommandHandler(YazilimKoyuContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(UpdateStudentCommand request, CancellationToken cancellationToken)
        {
            var updatedStudent = await _context.Students.FindAsync(request.Id);
            if (updatedStudent != null)
            {
                updatedStudent.Surname = request.Surname;
                updatedStudent.Number = request.Number;
                updatedStudent.Username = request.Username;
                updatedStudent.City = request.City;
                updatedStudent.Name = request.Name;
                updatedStudent.University = request.University;
                updatedStudent.Password = request.Password;
                _context.SaveChanges();
            }

            return Unit.Value;
        }
    }
}
