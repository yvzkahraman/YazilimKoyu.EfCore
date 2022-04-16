namespace E02.EFCoreApp.Data.Entities
{
    public class Course
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public int TeacherId { get; set; }

        public Teacher Teacher { get; set; } = new Teacher();

        public List<StudentCourse> StudentCourses { get; set; } = new List<StudentCourse>();
    }
}
