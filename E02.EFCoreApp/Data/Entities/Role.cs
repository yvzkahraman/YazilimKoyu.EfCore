namespace E02.EFCoreApp.Data.Entities
{
    public class Role
    {
        public int Id { get; set; }
        public string Definition { get; set; } = string.Empty;

        public List<Person>? People { get; set; } 
    }
}
