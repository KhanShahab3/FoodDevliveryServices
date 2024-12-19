using FoodDevliveryServices.Models;
using FoodDevliveryServices.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FoodDevliveryServices.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShopController : ControllerBase
    {
        private readonly IShopService _shopService;
        public ShopController(IShopService shopService)
        {
            _shopService = shopService;
        }
        [HttpGet]
        public async Task<ActionResult<List<Shop>>> GetAllShops()
        {
            var shops = await _shopService.GetAllShops();
            if (shops.Count == 0)
            {
                return new List<Shop>();
            }
            return Ok(shops);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<Shop>> GetShopById(int id)
        {
            var shop = await _shopService.GetShopById(id);
            if (shop == null)
            {
                return NotFound();
            }
            return Ok(shop);
        }
        [HttpPost]
        public async Task<ActionResult> AddShop(Shop shop)
        {
            await _shopService.AddShop(shop);
            return Ok(shop);
        }
        [HttpPut("{id}")]
        public async Task<ActionResult<Shop>> UpdateShop(Shop shop, int Id)
        {
            var updatedShop = await _shopService.UpdateShop(shop, Id);
            if (updatedShop != null)
                return Ok(updatedShop);
            return NotFound();
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult<bool>>DeleteShop(int id)
        {
            var deletedShop=await _shopService.DeleteShop(id);
            if (!deletedShop)
            {
                return NotFound();
            }
            return Ok();

        }
    }
}
