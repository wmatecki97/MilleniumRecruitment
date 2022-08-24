using Microsoft.EntityFrameworkCore;
using MilleniumRecruitment.Animals;
using MilleniumRecruitment.Repositories.Interfaces;

namespace MilleniumRecruitment.Repositories
{
    public class AnimalRepository : IAnimalRepository
    {
        private readonly ZooDbContext dbContext;

        public AnimalRepository(ZooDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public Animal[] GetAll()
        {
            return dbContext.Animals.AsNoTracking().ToArray();
        }

        public async Task<Animal> GetAsync(int id)
        {
            return await dbContext.Animals.FindAsync(id);
        }

        public async Task<Animal> AddAsync(Animal animal)
        {
            dbContext.Animals.Add(animal);
            await dbContext.SaveChangesAsync();
            return animal;
        }

        public async Task<Animal> DeleteAsync(int id)
        {
            var instance = await dbContext.Animals.FindAsync(id);
            dbContext.Remove(instance);
            await dbContext.SaveChangesAsync();
            return instance;
        }
    }
}
