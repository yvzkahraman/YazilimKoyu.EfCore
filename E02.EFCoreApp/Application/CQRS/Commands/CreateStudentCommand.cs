using MediatR;

namespace E02.EFCoreApp.Application.CQRS.Commands
{
    public class CreateStudentCommand : IRequest
    {
        //[Required]
        public string Name { get; set; } = string.Empty;
        public string Surname { get; set; } = string.Empty;

        public string Username { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;

        public string Number { get; set; } = string.Empty;

        public string University { get; set; } = string.Empty;

        public string City { get; set; } = string.Empty;
    }
}
