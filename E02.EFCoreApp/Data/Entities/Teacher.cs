namespace E02.EFCoreApp.Data.Entities
{
    public class Teacher : Person
    {
        public string Profession { get; set; } = string.Empty;

        public List<Course> Courses { get; set; } = new List<Course>();
    }
}
