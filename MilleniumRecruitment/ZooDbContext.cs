using Microsoft.EntityFrameworkCore;
using MilleniumRecruitment.Animals;

namespace MilleniumRecruitment
{
    public class ZooDbContext : DbContext
    {
        public ZooDbContext(DbContextOptions<ZooDbContext> options) : base(options)
        {
        }

        public DbSet<Animal> Animals { get; set; }
    }
}
