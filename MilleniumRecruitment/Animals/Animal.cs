using System.ComponentModel.DataAnnotations;

namespace MilleniumRecruitment.Animals
{
    public class Animal
    {
        [Key]
        public int Id { get; set; }
        
        [Required]
        public string Name { get; set; }
    }
}