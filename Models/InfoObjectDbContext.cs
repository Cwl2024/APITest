using Microsoft.EntityFrameworkCore;

namespace APITest2.Models
{
    public class InfoObjectDbContext : DbContext
    {
        public InfoObjectDbContext(DbContextOptions<InfoObjectDbContext> options)
            : base(options)
        {
        }

        public DbSet<InfoObject> InfoObjects { get; set; } = null!;
    }
}
