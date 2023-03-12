using Microsoft.EntityFrameworkCore;

namespace CourseDb.Models
{
    public class CourseContext : DbContext
    {
        public CourseContext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<Course> Courses { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("TrustServerCertificate=True;Server=LAPTOP-MTJR9ITS\\SQLEXPRESS;Database=courseManagement;Trusted_Connection=True");
        }

    }
}
