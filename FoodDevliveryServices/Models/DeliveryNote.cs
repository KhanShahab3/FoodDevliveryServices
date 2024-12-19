using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace FoodDevliveryServices.Models
{
    public class DeliveryNote
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; } 
        public int DeliveryId { get; set; }  
        public string Notes { get; set; }
        public string SentToEmail { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        public Delivery? Delivery { get; set; }
    }
}
