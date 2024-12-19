using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace FoodDevliveryServices.Models
{
    public class DeliveryRoute
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        
        public int Id { get; set; }
        public string RouteName { get; set; }
        public string StartingPoint { get; set; }
        public string EndPoint { get; set; }

       
        public List<Delivery>? Deliveries { get; set; }

        [JsonIgnore]
        public int? DriverId { get; set; }
        [ForeignKey("DriverId")]
        [JsonIgnore]
        public Drivers ?Driver { get; set; }
    }
}
