using Microsoft.EntityFrameworkCore;
using MilleniumRecruitment.Animals;

namespace MilleniumRecruitment
{
    public class ZooDbContext : DbContext
    {
        public DbSet<Animal> Animals { get; set; }
    }
}
