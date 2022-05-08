namespace E02.EFCoreApp.Data.Entities
{
    //, IEquatable<Student>
    public class Student : Person 
    {

        public string Number { get; set; } = string.Empty;

        public string University { get; set; } = string.Empty;

        public string City { get; set; } = string.Empty;

        public List<StudentCourse>? StudentCourses { get; set; }

        //public bool Equals(Student? other)
        //{
        //    return other?.City == this.City;
        //    throw new NotImplementedException();
        //}
    }
}
