using Microsoft.EntityFrameworkCore;

namespace ApiCoreClientEgitim.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
        public DbSet<Kurslar> Kurslar { get; set; }
        public DbSet<Katilimcilar> Katilimcilar { get; set; }
        public DbSet<Egitmenler> Egitmenler { get; set; }
        public DbSet<KursKatilim> KursKatilim { get; set; }

    }
}
