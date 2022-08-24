using System.ComponentModel.DataAnnotations;

namespace MilleniumRecruitment.Dtos
{
    public class UpdateAnimalDto
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
    }
}
