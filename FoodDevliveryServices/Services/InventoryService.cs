using FoodDevliveryServices.DataBaseContext;
using FoodDevliveryServices.Models;
using Microsoft.EntityFrameworkCore;

namespace FoodDevliveryServices.Services
{
    public class InventoryService:IInventoryService
    {
        private readonly AppDbContext _appDbContext;
        public InventoryService(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        public async Task AddInventory(Inventory inventory)
        {
            _appDbContext.Inventories.Add(inventory);
            await _appDbContext.SaveChangesAsync();
        }
        public async Task<List<Inventory>> GetAllInventories()
        {
            return await _appDbContext.Inventories.ToListAsync();
        }
        public async Task<Inventory> GetInventoryById(int id)
        {
         var inventory= await  _appDbContext.Inventories.FindAsync(id);
            return inventory;

        }
        public async Task<Inventory> UpdateInventory(Inventory inventory,int id)
        {
            var result = await _appDbContext.Inventories.FindAsync(id);
            if(result != null)
            {
                result.ItemName = inventory.ItemName;
                result.ShopId=inventory.ShopId;
                result.Quantity= inventory.Quantity;
                result.UpdatedAt = DateTime.Now;
                _appDbContext.Inventories.Update(inventory);
                await _appDbContext.SaveChangesAsync();
            }
            return result;

        }
        public async Task DeleteInventory(int id)
        {
            var deleteInventory = await _appDbContext.Inventories.FindAsync(id);
            if(deleteInventory != null)
            {
                _appDbContext.Inventories.Remove(deleteInventory); 
                await _appDbContext.SaveChangesAsync();
            }
        }
    }
}
