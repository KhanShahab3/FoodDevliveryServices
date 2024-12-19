using System.ComponentModel.DataAnnotations;

namespace FoodDevliveryServices.ModelDTO
{
    public class CreateDeliveryDto
    {
        [Required]
        public int ShopId { get; set; } 

        [Required]
        public int RouteId { get; set; } 

        [Required]
        public DateTime DeliveryDate { get; set; }

        [Required]
       
        public string Status { get; set; }
    }
}
