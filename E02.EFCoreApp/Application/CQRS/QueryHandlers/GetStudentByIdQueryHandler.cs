using E02.EFCoreApp.Application.CQRS.Queries;
using E02.EFCoreApp.Application.Dtos;
using E02.EFCoreApp.Data.Context;
using E02.EFCoreApp.Data.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace E02.EFCoreApp.Application.CQRS.QueryHandlers
{
    public class GetStudentByIdQueryHandler : IRequestHandler<GetStudentByIdQuery, StudentDto?>
    {
        private readonly YazilimKoyuContext _context;

        public GetStudentByIdQueryHandler(YazilimKoyuContext context)
        {
            _context = context;
        }
        public async Task<StudentDto?> Handle(GetStudentByIdQuery request, CancellationToken cancellationToken)
        {
            var student = await _context.People.AsNoTracking().OfType<Student>().Select(x => new StudentDto
            {
                Id = x.Id,
                Name = x.Name,
                City = x.City,
                Number = x.Number,
                Password = x.Password,
                Surname = x.Surname,
                University = x.University,
                Username = x.Username,
            }).SingleOrDefaultAsync(p => p.Id == request.Id);


            return student;
        }
    }
}
