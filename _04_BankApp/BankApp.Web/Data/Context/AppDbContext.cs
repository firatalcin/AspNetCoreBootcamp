using BankApp.Web.Data.Configurations;
using BankApp.Web.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace BankApp.Web.Data.Context
{
    public class AppDbContext : DbContext
    {
        public DbSet<Account> Accounts { get; set; }
        public DbSet<ApplicationUser> ApplicationUsers { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> optionBuilder) : base(optionBuilder)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ApplicationUserConfiguration());
            modelBuilder.ApplyConfiguration(new AccountConfiguration());
        }
    }
}
