using System.ComponentModel.DataAnnotations;

namespace TutorialNET5WebAPI.Models.Dtos
{
    public class CreateItemDto
    {
        [Required]
        public string Name { get; set; }
        [Required]
        [Range(0, 2048)]
        public decimal Price { get; set; }
    }
}
