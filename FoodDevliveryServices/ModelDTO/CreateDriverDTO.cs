using System.ComponentModel.DataAnnotations;

namespace FoodDevliveryServices.ModelDTO
{
    public class CreateDriverDTO
    {
        public string FullName { get; set; }
        public string Email { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime? UpdatedAt { get; set; } = DateTime.Now;
       
    }
}
