using FoodDevliveryServices.DataBaseContext;
using FoodDevliveryServices.Models;
using Microsoft.EntityFrameworkCore;

namespace FoodDevliveryServices.Services
{
    public class ShopService:IShopService
    {
        private readonly AppDbContext _context;
        public ShopService(AppDbContext context)
        {
            _context = context;
        }
        public async Task AddShop(Shop shop)
        {
            
            shop.CreatedAt = DateTime.UtcNow;
            shop.UpdatedAt = DateTime.UtcNow;
            _context.Shops.Add(shop);
            await _context.SaveChangesAsync();
        }
        public async Task<List<Shop>> GetAllShops()
        {
            return await _context.Shops.ToListAsync();
        }
        public async Task<Shop> GetShopById(int Id)
        {
            var shop = await _context.Shops.FindAsync(Id);
            return shop;
        }
        public async Task<Shop> UpdateShop(Shop shops, int Id)
        {
            var shop = await _context.Shops.FindAsync(Id);
            if (shop != null)
            {
                shop.Name = shops.Name;
                shop.Address = shops.Address;
                shop.ContactInfo = shops.ContactInfo;
                shop.UpdatedAt = DateTime.UtcNow;
            }
            _context.Shops.Update(shops);
          await _context.SaveChangesAsync();
            return shop;
        }
        public async Task<bool> DeleteShop(int Id)
        {
            var deletedShop = await _context.Shops.FindAsync(Id);
            if(deletedShop != null)
            {
                _context.Shops.Remove(deletedShop);
                await _context.SaveChangesAsync();
            }
            return true;
        }

    }
}
