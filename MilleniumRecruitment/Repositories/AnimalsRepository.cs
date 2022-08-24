using Microsoft.EntityFrameworkCore;
using MilleniumRecruitment.Animals;
using MilleniumRecruitment.Repositories.Interfaces;

namespace MilleniumRecruitment.Repositories
{
    public class AnimalRepository : IAnimalRepository
    {
        private readonly ZooDbContext dbContext;
        private readonly ILogger<AnimalRepository> logger;

        public AnimalRepository(ZooDbContext dbContext, ILogger<AnimalRepository> logger)
        {
            this.dbContext = dbContext;
            this.logger = logger;
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

        public async Task<Animal> UpdateAsync(Animal animal)
        {
            if (dbContext.Animals.All(a => a.Id != animal.Id))
            {
                logger.LogWarning($"Trying to update not existing Animal entry with id {animal.Id}");
                throw new Exception("The given entry does not exist");
            }

            dbContext.Animals.Attach(animal);
            dbContext.Entry(animal).Property(a => a.Name).IsModified = true;

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
