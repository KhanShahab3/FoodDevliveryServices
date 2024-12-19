using FoodDevliveryServices.Models;

namespace FoodDevliveryServices.Services
{
    public interface IInventoryService
    {
        Task AddInventory(Inventory inventory);
        Task<List<Inventory>> GetAllInventories();
      
        Task<Inventory> GetInventoryById(int id);
        Task<Inventory>UpdateInventory(Inventory inventory,int id);
        Task DeleteInventory(int id);

    }
}
