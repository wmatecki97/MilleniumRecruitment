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


        [HttpGet("{id}")]
        public ActionResult<Animal> Get(int id)
        {
            return Ok(repository.GetAsync(id));
        }

        [HttpGet()]
        public ActionResult<Animal> GetAll()
        {
            return Ok(repository.GetAll());
        }

        [HttpPost()]
        public async Task<ActionResult<Animal>> PostAsync([FromBody] Animal animal)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            return await repository.AddAsync(animal);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Animal>> Delete(int id)
        {
            return await repository.DeleteAsync(id);
        }
    }
}

