using MediatR;

namespace E02.EFCoreApp.Application.CQRS.Commands
{
    public class CreateTeacherCommand : IRequest
    {
        public string Name { get; set; } = string.Empty;
        public string Surname { get; set; } = string.Empty;

        public string Username { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;

        public string Number { get; set; } = string.Empty;

        public string Profession { get; set; } = string.Empty;

        public int RoleId { get; set; }
    }
}
