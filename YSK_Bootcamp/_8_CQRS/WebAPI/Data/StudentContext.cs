using Microsoft.EntityFrameworkCore;

namespace WebAPI.Data
{
    public class StudentContext : DbContext
    {
        public StudentContext(DbContextOptions<StudentContext> options) : base(options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Student>().HasData(new Student[]
            {
                new Student { Name = "Fırat", Age = 26, Surname = "Alçın", Id = 1 },
                new Student { Name = "Enes", Age = 26, Surname = "Çiçek", Id = 2}
            });
        }

        public DbSet<Student> Students { get; set; }
    }
}
