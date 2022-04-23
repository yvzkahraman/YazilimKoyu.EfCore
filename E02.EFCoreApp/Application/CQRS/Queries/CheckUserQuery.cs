using E02.EFCoreApp.Application.Dtos;
using E02.EFCoreApp.Data.Entities;
using MediatR;

namespace E02.EFCoreApp.Application.CQRS.Queries
{
    public class CheckUserQuery : IRequest<PersonDto?>
    {

        public string Username { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
    }
}
