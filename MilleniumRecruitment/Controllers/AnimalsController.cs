using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MilleniumRecruitment.Animals;
using MilleniumRecruitment.Repositories;
using MilleniumRecruitment.Repositories.Interfaces;

namespace MilleniumRecruitment.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AnimalController : ControllerBase
    {

        private readonly ILogger<AnimalController> _logger;
        private readonly IAnimalRepository repository;

        public AnimalController(ILogger<AnimalController> logger, IAnimalRepository repository)
        {
            _logger = logger;
            this.repository = repository;
        }


        [HttpGet("{id}.{format}"), FormatFilter]
        public async Task<ActionResult<Animal>> GetAsync(int id)
        {
            return Ok(await repository.GetAsync(id));
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

        [HttpDelete("{id}.{format}"), FormatFilter]
        public async Task<ActionResult<Animal>> Delete(int id)
        {
            return await repository.DeleteAsync(id);
        }
    }
}

