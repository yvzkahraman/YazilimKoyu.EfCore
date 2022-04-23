namespace E02.EFCoreApp.Data.Entities
{
    public class Student : Person
    {

        public string Number { get; set; } = string.Empty;

        public string University { get; set; } = string.Empty;

        public string City { get; set; } = string.Empty;

        public List<StudentCourse>? StudentCourses { get; set; }
    }
}
