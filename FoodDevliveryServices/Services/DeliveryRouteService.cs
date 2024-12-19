using FoodDevliveryServices.DataBaseContext;
using FoodDevliveryServices.ModelDTO;
using FoodDevliveryServices.Models;
using Microsoft.EntityFrameworkCore;

namespace FoodDevliveryServices.Services
{
    public class DeliveryRouteService:IDeliveryRouteService
    {
        private readonly AppDbContext _context;
        public DeliveryRouteService(AppDbContext context)
        {
            _context = context;
        }
        public async Task<DeliveryRoute> AddRouteAsync(DeliveryRouteDto routeDto)
        {
            if (routeDto == null)
            {
                throw new ArgumentNullException(nameof(routeDto), "Invalid route data.");
            }
            var driverId = routeDto.DriverId == 0 ? (int?)null : routeDto.DriverId;

            // Map the DTO to the DeliveryRoute entity
            var route = new DeliveryRoute
            {
                RouteName = routeDto.RouteName,
                StartingPoint = routeDto.StartingPoint,
                EndPoint = routeDto.EndPoint,
                DriverId = driverId // Optional, can be null
            };

            // Add the new route to the database context
            _context.DeliveryRoutes.Add(route);
            await _context.SaveChangesAsync();

            return route; // Return the created route
        }
        public async Task<List<DeliveryRoute>> GetAllRoutes()
        {
            return await _context.DeliveryRoutes.ToListAsync();
        }
        public async Task<DeliveryRoute> GetRouteById(int Id)
        {
          var route=await _context.DeliveryRoutes.FindAsync(Id);
            return route;
           

        }
        public async Task<DeliveryRoute> UpdateRouteAsync(int id, DeliveryRouteDto routeDto)
        {
            if (routeDto == null)
            {
                throw new ArgumentNullException(nameof(routeDto), "Invalid route data.");
            }

            // Find the existing route by Id
            var route = await _context.DeliveryRoutes.FindAsync(id);

            if (route == null)
            {
                // Handle not found route
                throw new KeyNotFoundException($"Route with ID {id} not found.");
            }

            // Map the updated values from the DTO to the existing entity
            route.RouteName = routeDto.RouteName;
            route.StartingPoint = routeDto.StartingPoint;
            route.EndPoint = routeDto.EndPoint;
            route.DriverId = routeDto.DriverId; 

            // Mark the entity as modified
            _context.DeliveryRoutes.Update(route);

            // Save changes to the database
            await _context.SaveChangesAsync();

            // Return the updated route
            return route;
        }
        public async Task<bool> DeleteRoute(int Id)
        {
            var result = await _context.DeliveryRoutes.FindAsync(Id);
            if (result != null)
            {
                 _context.DeliveryRoutes.Remove(result);
                await _context.SaveChangesAsync();
            }
            return true;
        }
    }
}
