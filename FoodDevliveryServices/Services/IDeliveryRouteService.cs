using FoodDevliveryServices.ModelDTO;
using FoodDevliveryServices.Models;

namespace FoodDevliveryServices.Services
{
    public interface IDeliveryRouteService
    {
        Task<DeliveryRoute> AddRouteAsync(DeliveryRouteDto routeDto);
        Task<List<DeliveryRoute>> GetAllRoutes();
        Task<DeliveryRoute> GetRouteById(int Id);
        Task<DeliveryRoute> UpdateRouteAsync(int id, DeliveryRouteDto routeDto);
        Task<bool> DeleteRoute(int Id);
    }
}
