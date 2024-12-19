using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace FoodDevliveryServices.Models
{
    public class Delivery
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int ShopId { get; set; }
        public int RouteId { get; set; }
        public DateTime DeliveryDate { get; set; }
        public string Status { get; set; }

        [ForeignKey("RouteId")]
        public DeliveryRoute? DeliveryRoutes { get; set; }
        [ForeignKey("ShopId")]
        public Shop? Shop { get; set; }

        [JsonIgnore]
        public DeliveryNote ?DeliveryNote { get; set; }
    }
}
