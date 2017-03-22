using Microsoft.EntityFrameworkCore;
 
namespace restaurantreviews.Models
{
    public class rrContext : DbContext
    {
        public rrContext(DbContextOptions<rrContext> options) : base(options) { }
         public DbSet<Review> reviews { get; set; }
    }
}