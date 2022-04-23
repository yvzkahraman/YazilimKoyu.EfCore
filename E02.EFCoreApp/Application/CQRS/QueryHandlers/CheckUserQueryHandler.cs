using E02.EFCoreApp.Application.CQRS.Queries;
using E02.EFCoreApp.Application.Dtos;
using E02.EFCoreApp.Data.Context;
using E02.EFCoreApp.Data.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace E02.EFCoreApp.Application.CQRS.QueryHandlers
{
    public class CheckUserQueryHandler : IRequestHandler<CheckUserQuery, PersonDto?>
    {
        private readonly YazilimKoyuContext _context;

        public CheckUserQueryHandler(YazilimKoyuContext context)
        {
            _context = context;
        }

        public async Task<PersonDto?> Handle(CheckUserQuery request, CancellationToken cancellationToken)
        {
            // lazy, eagle, explicit
           var person = await _context.People.Include(x=>x.Role).Select(x=> new PersonDto
           {
               Id = x.Id,
               Name = x.Name,
               Password= x.Password,
               RoleDefinition=x.Role.Definition,
               RoleId=x.RoleId,
               Surname=x.Surname,
               Username=x.Username,
           }).AsNoTracking().SingleOrDefaultAsync(x=>x.Username == request.Username && x.Password == request.Password);

            return person;
        }
    }
}
