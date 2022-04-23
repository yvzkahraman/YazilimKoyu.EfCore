namespace E02.EFCoreApp.Application.Dtos
{
    public class PersonDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Surname { get; set; } = string.Empty;

        public string Username { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;

        public int RoleId { get; set; }

        public string RoleDefinition { get; set; } = string.Empty;
    }
}
