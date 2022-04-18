using E02.EFCoreApp.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace E02.EFCoreApp.Data.Context
{
    public class YazilimKoyuContext : DbContext
    {
        public YazilimKoyuContext(DbContextOptions<YazilimKoyuContext> options) : base(options)
        {
        }

        public DbSet<Person> People => Set<Person>();
        public DbSet<Student> Students => Set<Student>();

        public DbSet<Teacher> Teachers => Set<Teacher>();

        public DbSet<Course> Courses => Set<Course>();

        public DbSet<StudentCourse> StudentCourses => Set<StudentCourse>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Teacher>().ToTable("Teachers");
            modelBuilder.Entity<Student>().ToTable("Students");

            modelBuilder.Entity<Student>().HasMany(x => x.StudentCourses).WithOne(x => x.Student).HasForeignKey(x => x.StudentId).OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<Course>().HasMany(x => x.StudentCourses).WithOne(x => x.Course).HasForeignKey(x => x.CourseId).OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<StudentCourse>().HasKey(x => new { x.StudentId, x.CourseId });

            base.OnModelCreating(modelBuilder);
        }
    }
}
