namespace FoodDevliveryServices.ModelDTO
{
    public class AssignRouteRequest
    {
        public int DriverId { get; set; }
        public List<int> RouteIds { get; set; }
    }
}
