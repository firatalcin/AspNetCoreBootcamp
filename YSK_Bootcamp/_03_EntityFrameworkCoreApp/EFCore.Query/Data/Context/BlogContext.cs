using EFCore.Query.Data.Configurations;
using EFCore.Query.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace EFCore.Query.Data.Context
{
    public class BlogContext : DbContext
    {
        public DbSet<Blog> Blogs { get; set; }
        public DbSet<Comment> Comments { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("server=MAKINA\\SQLEXPRESS01; database= EFCoreQuery; integrated security=true;TrustServerCertificate=True");
            optionsBuilder.LogTo(Console.WriteLine, Microsoft.Extensions.Logging.LogLevel.Information);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new BlogConfiguration());
            modelBuilder.ApplyConfiguration(new CommentConfiguration());
        }
    }
}
