using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MilleniumRecruitment.Animals;

namespace MilleniumRecruitment.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AnimalController : ControllerBase
    {

        private readonly ILogger<AnimalController> _logger;

        public AnimalController(ILogger<AnimalController> logger)
        {
            _logger = logger;
        }


        [HttpGet(Name = "Get")]
        public IEnumerable<Animal> Get()
        {
            return null;
        }
    }
}

