using System.ComponentModel.DataAnnotations;

namespace MilleniumRecruitment.Animals
{
    public class Animal
    {
        [Key]
        public int Id { get; internal set; }
        
        [Required]
        public string Name { get; set; }
    }
}