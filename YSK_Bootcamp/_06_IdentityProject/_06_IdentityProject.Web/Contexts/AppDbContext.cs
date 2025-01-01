using _06_IdentityProject.Web.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace _06_IdentityProject.Web.Contexts
{
    public class AppDbContext : IdentityDbContext<AppUser,AppRole, int>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
            
        }
    }
}
