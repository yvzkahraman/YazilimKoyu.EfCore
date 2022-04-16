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
    }
}
