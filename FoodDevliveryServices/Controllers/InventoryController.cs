using FoodDevliveryServices.Models;
using FoodDevliveryServices.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FoodDevliveryServices.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InventoryController : ControllerBase
    {
        private readonly IInventoryService _inventoryService;
        public InventoryController(IInventoryService inventoryService)
        {
            _inventoryService = inventoryService;
        }
        [HttpGet]
        public async Task<ActionResult<List<Inventory>>> GetAllInventories()
        {
            var inventories = await _inventoryService.GetAllInventories();
            if (inventories.Count == 0)
                return new List<Inventory>();
            return Ok(inventories);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<Inventory>>GetInventoryById(int id)
        {
            var inventory=await _inventoryService.GetInventoryById(id);
            if (inventory == null)
                return NotFound();
            return Ok(inventory);
        }
        [HttpPost]
        public async Task<ActionResult>AddInventory(Inventory inventory)
        {
            await _inventoryService.AddInventory(inventory);
            return Ok("Inventory Created....!");
        }
        [HttpPut("{id}")]
        public async Task<ActionResult<Inventory>>UpdateInventory(Inventory inventory,int id)
        {
            var updatedInventory = await _inventoryService.UpdateInventory(inventory, id);
            if (updatedInventory == null)
                return BadRequest();
            return Ok("Inventory Updated......!");
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteInventory(int id)
        {
            await _inventoryService.DeleteInventory(id);
            return Ok("Inventory Deleted.....!");
        }
    }
}
