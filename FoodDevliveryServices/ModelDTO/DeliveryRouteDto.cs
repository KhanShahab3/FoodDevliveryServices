namespace FoodDevliveryServices.ModelDTO
{
    public class DeliveryRouteDto
    {
        public string RouteName { get; set; }
        public string StartingPoint { get; set; }
        public string EndPoint { get; set; }
        public int? DriverId { get; set; }
    }
}
