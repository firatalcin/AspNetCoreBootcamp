using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace ProductApi.Models;

public class ProductContext : IdentityDbContext<AppUser, AppRole, int>
{
    public ProductContext(DbContextOptions<ProductContext> options) : base(options)
    {
        
    }

    public DbSet<Product> Products { get; set; }
}