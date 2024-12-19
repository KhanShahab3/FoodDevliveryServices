using FoodDevliveryServices.DataBaseContext;
using FoodDevliveryServices.ModelDTO;

using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FoodDevliveryServices.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AssignDeliveryRouteController : ControllerBase
    {
        private readonly AppDbContext _appDbContext;

        public AssignDeliveryRouteController(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        [HttpPost("assign-multiple")]
        public IActionResult AssignMultipleRoutesToDriver([FromBody] AssignRouteRequest request)
        {
            // Check if driver exists
            var driver = _appDbContext.Drivers.FirstOrDefault(d => d.Id == request.DriverId);
            if (driver == null)
            {
                return NotFound("Driver not found");
            }

            // Validate routes
            var validRoutes = _appDbContext.DeliveryRoutes
                .Where(r => request.RouteIds.Contains(r.Id))
                .ToList();

            if (!validRoutes.Any())
            {
                return NotFound("No valid routes found");
            }

            foreach (var route in validRoutes)
            {
                // Assign each route to the driver if not already assigned
                if (route.DriverId != request.DriverId)
                {
                    route.DriverId = request.DriverId;
                }
            }

            _appDbContext.SaveChanges();

            return Ok($"Routes successfully assigned to Driver {request.DriverId}");
        }

        [HttpGet("api/drivers/{driverId}/deliveries")]
        public IActionResult GetDriverDeliveries(int driverId)
        {
            var route = _appDbContext.DeliveryRoutes
                .Include(r => r.Deliveries)
                .ThenInclude(d => d.Shop)  
                .FirstOrDefault(r => r.DriverId == driverId);

            if (route == null) return NotFound("No assigned route for this driver");

            return Ok(new
            {
                RouteName = route.RouteName,
                Deliveries = route.Deliveries.Select(d => new
                {
                    d.Id,
                    d.Shop.Name,
                    d.Shop.Address,
                    d.DeliveryDate,
                    d.Status
                })
            });
        }

    }
}






