using System.ComponentModel.DataAnnotations;

namespace FoodDevliveryServices.ModelDTO
{
    public class LogInDTO
    {
        [Required]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }
        
    }
}
