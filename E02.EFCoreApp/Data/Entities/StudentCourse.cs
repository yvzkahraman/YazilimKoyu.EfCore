namespace E02.EFCoreApp.Data.Entities
{
    public class StudentCourse
    {
        public int StudentId { get; set; }

        public Student Student { get; set; } = new Student();

        public int CourseId { get; set; }

        public Course Course { get; set; } = new Course();

        public int? CoursePoint { get; set; }
    }
}
