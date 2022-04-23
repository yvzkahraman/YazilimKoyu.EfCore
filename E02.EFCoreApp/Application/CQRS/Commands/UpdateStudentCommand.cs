using MediatR;

namespace E02.EFCoreApp.Application.CQRS.Commands
{
    public class UpdateStudentCommand : IRequest
    {
        //public UpdateStudentCommand(int id, string name, string surname, string username, string password, string number, string university, string city)
        //{
        //    Id = id;
        //    Name = name;
        //    Surname = surname;
        //    Username = username;
        //    Password = password;
        //    Number = number;
        //    University = university;
        //    City = city;
        //}

        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Surname { get; set; } = string.Empty;

        public string Username { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;

        public string Number { get; set; } = string.Empty;

        public string University { get; set; } = string.Empty;

        public string City { get; set; } = string.Empty;

        public int RoleId { get; set; }
    }
}
