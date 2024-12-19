using System.ComponentModel.DataAnnotations;

namespace FoodDevliveryServices.ModelDTO
{
    public class UpdateDeliveryDto
    {
        public int? ShopId { get; set; }
        public int? RouteId { get; set; }
        public DateTime? DeliveryDate { get; set; }

        [StringLength(50)]
        public string? Status { get; set; }
    }
}
