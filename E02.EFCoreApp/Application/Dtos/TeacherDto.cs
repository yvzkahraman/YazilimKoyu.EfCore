namespace E02.EFCoreApp.Application.Dtos
{
    public class TeacherDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Surname { get; set; } = string.Empty;

        public string Username { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public string Profession { get; set; } = string.Empty;

    }
}
