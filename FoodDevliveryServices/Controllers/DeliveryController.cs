using FoodDevliveryServices.ModelDTO;
using FoodDevliveryServices.Models;
using FoodDevliveryServices.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FoodDevliveryServices.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DeliveryController : ControllerBase
    {
        private readonly IDeliveryService _delivery;
        public DeliveryController(IDeliveryService delivery)
        {
            _delivery = delivery;
        }
        [HttpGet]
        public async Task<ActionResult<List<Delivery>>> GetAllDeliveries()
        {
            var deliveries = await _delivery.GetDeliveryList();
            if (deliveries.Count == 0)
                return new List<Delivery>();
            return Ok(deliveries);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<Delivery>> GetDeliveryById(int id)
        {
            var delivery = await _delivery.GetDeliveryById(id);
            if (delivery == null)
                return NotFound();
            return Ok(delivery);
        }
        [HttpPost]
        public async Task<ActionResult> AddDelivery(CreateDeliveryDto delivery)
        {
            await _delivery.AddDelivery(delivery);
            return Ok("Inventory Created....!");
        }
        [HttpPut("{id}")]
        public async Task<ActionResult<Delivery>> UpdateDelivery(UpdateDeliveryDto delivery, int id)
        {
           await _delivery.UpdateDelivery(delivery,id);
            
               
            return Ok("Inventory Updated......!");
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteDelivery(int id)
        {
            await _delivery.DeleteDelivery(id);
            return Ok("Inventory Deleted.....!");
        }
    }
}
