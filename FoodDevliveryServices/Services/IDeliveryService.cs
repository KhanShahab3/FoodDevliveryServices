using FoodDevliveryServices.ModelDTO;
using FoodDevliveryServices.Models;

namespace FoodDevliveryServices.Services
{
    public interface IDeliveryService
    {
        Task AddDelivery(CreateDeliveryDto deliveryDto);
        Task<List<Delivery>> GetDeliveryList(); 
        Task DeleteDelivery(int id);
        Task UpdateDelivery(UpdateDeliveryDto deliveryDto, int id);
        Task<Delivery> GetDeliveryById(int id);
    }
}
