using MilleniumRecruitment.Animals;

namespace MilleniumRecruitment.Repositories
{
    public class AnimalsRepository
    {
        private readonly ZooDbContext dbContext;

        public AnimalsRepository(ZooDbContext dbContext)
        {
            dbContext = dbContext;
        }

        public Animal[] GetAll()
        {
            return dbContext.Animals.ToArray();
        }

        public Animal Get(int id)
        {
            return dbContext.Animals.FirstOrDefault(a => a.Id == id);
        }
    }
}
