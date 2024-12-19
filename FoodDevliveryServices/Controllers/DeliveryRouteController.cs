using FoodDevliveryServices.ModelDTO;
using FoodDevliveryServices.Models;
using FoodDevliveryServices.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FoodDevliveryServices.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DeliveryRouteController : ControllerBase
    {
        private readonly IDeliveryRouteService _routeService;
        public DeliveryRouteController(IDeliveryRouteService routeService)
        {
            _routeService = routeService;

        }
        [HttpPost]
        public async Task<ActionResult> AddDeliveryRoute(DeliveryRouteDto route)
        {
            await _routeService.AddRouteAsync(route);
            return Ok("route are created....!");

        }
        [HttpGet]
        public async Task<ActionResult<List<DeliveryRoute>>> GetAllDeliveryRoutes()
        {
            var routes = await _routeService.GetAllRoutes();
            if (routes.Count == 0)
            {
                return new List<DeliveryRoute>();
            }
            return Ok(routes);
        }
        [HttpGet("{Id}")]
        public async Task<ActionResult<DeliveryRoute>> GetDeliveryRoutesById(int Id)
        {
            var route = await _routeService.GetRouteById(Id);
            if (route == null)
                return NotFound();
            return Ok(route);
        }
        [HttpDelete("{Id}")]
        public async Task<ActionResult> DeleteDeliveryRoute(int Id)
        {
            var result = await _routeService.DeleteRoute(Id);
            return Ok(result);

        }
        [HttpPut("{Id}")]
        public async Task<ActionResult<DeliveryRoute>> UpdateShop(DeliveryRouteDto route, int Id)
        {
            var updatedRoute = await _routeService.UpdateRouteAsync(Id,route);
            if (updatedRoute != null)
                return Ok(updatedRoute);
            return NotFound();
        }
      

    }
}
