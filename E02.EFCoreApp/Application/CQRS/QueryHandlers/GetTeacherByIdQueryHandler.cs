using E02.EFCoreApp.Application.CQRS.Queries;
using E02.EFCoreApp.Application.Dtos;
using E02.EFCoreApp.Data.Context;
using E02.EFCoreApp.Data.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace E02.EFCoreApp.Application.CQRS.QueryHandlers
{
    public class GetTeacherByIdQueryHandler : IRequestHandler<GetTeacherByIdQuery, TeacherDto?>
    {
        private readonly YazilimKoyuContext _context;

        public GetTeacherByIdQueryHandler(YazilimKoyuContext context)
        {
            _context = context;
        }

        public async Task<TeacherDto?> Handle(GetTeacherByIdQuery request, CancellationToken cancellationToken)
        {
            var teacher = await _context.People.OfType<Teacher>().AsNoTracking().Select(x => new TeacherDto
            {
                Id = x.Id,
                Name = x.Name,
                Password = x.Password,
                Profession = x.Profession,
                Surname = x.Surname,
                Username = x.Username,
            }).SingleOrDefaultAsync(x => x.Id == request.Id);

            return teacher;
        }
    }
}
