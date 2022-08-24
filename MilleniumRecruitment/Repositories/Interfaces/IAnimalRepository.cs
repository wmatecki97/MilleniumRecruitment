using MilleniumRecruitment.Animals;

namespace MilleniumRecruitment.Repositories.Interfaces
{
    public interface IAnimalRepository
    {
        Task<Animal> AddAsync(Animal animal);
        Task<Animal> DeleteAsync(int id);
        Animal[] GetAll();
        Task<Animal> GetAsync(int id);
    }
}