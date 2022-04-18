namespace E02.EFCoreApp.Application.Dtos
{
    public class StudentDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Surname { get; set; } = string.Empty;

        public string Username { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;

        public string Number { get; set; } = string.Empty;

        public string University { get; set; } = string.Empty;

        public string City { get; set; } = string.Empty;
    }
}
