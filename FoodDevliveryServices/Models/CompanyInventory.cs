using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace FoodDevliveryServices.Models
{
    public class CompanyInventory
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }  
        public string ItemName { get; set; } 
        public int Quantity { get; set; } 
        public DateTime CreatedAt { get; set; }  
        public DateTime UpdatedAt { get; set; }  

        
        public ICollection<DeliveryItem> DeliveryItems { get; set; }
    }
}
