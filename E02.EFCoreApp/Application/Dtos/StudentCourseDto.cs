namespace E02.EFCoreApp.Application.Dtos
{
    public class StudentCourseDto
    {
        public int CourseId { get; set; }
        public int StudentId { get; set; }
        public string Fullname { get; set; }
        public bool IsExist { get; set; }
    }
}
