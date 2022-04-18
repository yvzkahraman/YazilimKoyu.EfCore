using E02.EFCoreApp.Application.CQRS.Queries;
using E02.EFCoreApp.Application.Dtos;
using E02.EFCoreApp.Data.Context;
using E02.EFCoreApp.Data.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace E02.EFCoreApp.Application.CQRS.QueryHandlers
{
    public class GetStudentListQueryHandler : IRequestHandler<GetStudentListQuery, List<StudentDto>>
    {
        private readonly YazilimKoyuContext _context;

        public GetStudentListQueryHandler(YazilimKoyuContext context)
        {
            _context = context;
        }

        public async Task<List<StudentDto>> Handle(GetStudentListQuery request, CancellationToken cancellationToken)
        {
            var studentList = await _context.People.OfType<Student>().Select(x => new StudentDto
            {
                Id = x.Id,
                Name = x.Name,
                City = x.City,
                Number = x.Number,
                Password = x.Password,
                Surname = x.Surname,
                University = x.University,
                Username = x.Username,
            }).AsNoTracking().ToListAsync();

            return studentList;
        }
    }
}
