using Microsoft.AspNetCore.Mvc;
using MilleniumRecruitment.Animals;
using MilleniumRecruitment.Dtos;
using MilleniumRecruitment.Repositories.Interfaces;

namespace MilleniumRecruitment.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AnimalController : ControllerBase
    {
        private readonly IAnimalRepository repository;

        public AnimalController(IAnimalRepository repository)
        {
            this.repository = repository;
        }


        [HttpGet("{id}.{format}"), FormatFilter]
        public async Task<ActionResult<Animal>> GetAsync(int id)
        {
            var result = await repository.GetAsync(id);
            if(result is null)
            {
                return NotFound();
            }

            return Ok(result);
        }

        [HttpGet("{format}"), FormatFilter]
        public ActionResult<Animal> GetAll()
        {
            return Ok(repository.GetAll());
        }

        [HttpPost("{format}"), FormatFilter]
        public async Task<ActionResult<Animal>> PostAsync([FromBody] Animal animal)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            return await repository.AddAsync(animal);
        }

        [HttpPut("{format}"), FormatFilter]
        public async Task<ActionResult<Animal>> PutAsync([FromBody] UpdateAnimalDto animal)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            //todo automapper
            var animalToUpdate = new Animal
            {
                Id = animal.Id,
                Name = animal.Name
            };

            return await repository.UpdateAsync(animalToUpdate);
        }

        [HttpDelete("{id}.{format}"), FormatFilter]
        public async Task<ActionResult> Delete(int id)
        {
            var IsSuccess = await repository.TryDeleteAsync(id);
            if (!IsSuccess)
            {
                return BadRequest(ModelState);
            }

            return Ok();
        }
    }
}

