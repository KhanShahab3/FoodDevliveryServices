namespace FoodDevliveryServices.ModelDTO
{
    public class DeliveryDTO
    {
        public int Id { get; set; }
        public DateTime DeliveryDate { get; set; }
        public string Status { get; set; }
        public DeliveryRouteFetchDto DeliveryRoute { get; set; }
        public ShopDto Shop { get; set; }
    }
}
