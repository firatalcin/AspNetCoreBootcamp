using MarketService.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace MarketService.Data.Contexts
{
    public class MarketContext : DbContext
    {
        public MarketContext(DbContextOptions<MarketContext> options) : base(options)
        {

        }
        public DbSet<Market> Markets { get; set; }
    }
}
