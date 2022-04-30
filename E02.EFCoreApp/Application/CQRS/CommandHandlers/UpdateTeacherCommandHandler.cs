using E02.EFCoreApp.Application.CQRS.Commands;
using E02.EFCoreApp.Application.Enums;
using E02.EFCoreApp.Data.Context;
using E02.EFCoreApp.Data.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace E02.EFCoreApp.Application.CQRS.CommandHandlers
{
    public class UpdateTeacherCommandHandler : IRequestHandler<UpdateTeacherCommand>
    {
        private readonly YazilimKoyuContext _context;

        public UpdateTeacherCommandHandler(YazilimKoyuContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(UpdateTeacherCommand request, CancellationToken cancellationToken)
        {
            var updatedTeacher = await _context.People.OfType<Teacher>().SingleOrDefaultAsync(x => x.Id == request.Id);
            if(updatedTeacher != null)
            {
                updatedTeacher.Surname = request.Surname;
                updatedTeacher.Username = request.Username;
                updatedTeacher.Profession = request.Profession;
                updatedTeacher.Name= request.Name;
                updatedTeacher.Password = request.Password;
                updatedTeacher.RoleId = (int)RoleType.Teacher;
                await _context.SaveChangesAsync();
            }
            return Unit.Value;
        }
    }
}
