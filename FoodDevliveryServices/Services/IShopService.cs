using FoodDevliveryServices.Models;

namespace FoodDevliveryServices.Services
{
    public interface IShopService
    {
        Task AddShop(Shop shop);
        Task<List<Shop>> GetAllShops();
        Task<Shop> GetShopById(int Id);
        Task<Shop> UpdateShop(Shop shop, int Id);
        Task<bool> DeleteShop(int Id);

    }
}
