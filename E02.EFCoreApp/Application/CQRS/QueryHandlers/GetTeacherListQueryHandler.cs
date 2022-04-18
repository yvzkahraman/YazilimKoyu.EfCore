using E02.EFCoreApp.Application.CQRS.Queries;
using E02.EFCoreApp.Application.Dtos;
using E02.EFCoreApp.Data.Context;
using E02.EFCoreApp.Data.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace E02.EFCoreApp.Application.CQRS.QueryHandlers
{
    public class GetTeacherListQueryHandler : IRequestHandler<GetTeacherListQuery, List<TeacherDto>>
    {
        private readonly YazilimKoyuContext _context;

        public GetTeacherListQueryHandler(YazilimKoyuContext context)
        {
            _context = context;
        }

        public async Task<List<TeacherDto>> Handle(GetTeacherListQuery request, CancellationToken cancellationToken)
        {
            return await _context.People.OfType<Teacher>().AsNoTracking().Select(x => new TeacherDto
            {
                Id = x.Id,
                Name = x.Name,
                Password = x.Password,
                Profession = x.Profession,
                Surname = x.Surname,
                Username = x.Username,
            }).ToListAsync();
        }
    }
}
