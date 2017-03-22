using Microsoft.EntityFrameworkCore;
 
namespace bankaccounts.Models
{
    public class baContext : DbContext
    {
        public baContext(DbContextOptions<baContext> options) : base(options) { }
         public DbSet<Account> accounts { get; set; }
    }
}