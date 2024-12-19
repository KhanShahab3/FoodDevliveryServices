using FoodDevliveryServices.DataBaseContext;
using FoodDevliveryServices.ModelDTO;
using FoodDevliveryServices.Models;
using Microsoft.AspNetCore.Razor.TagHelpers;
using Microsoft.EntityFrameworkCore;

namespace FoodDevliveryServices.Services
{
    public class DeliveryService:IDeliveryService
    {
        private readonly AppDbContext  _appDbContext;
        public DeliveryService(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        public async Task AddDelivery(CreateDeliveryDto deliveryDto)
        {
         
            var delivery = new Delivery
            {
                ShopId = deliveryDto.ShopId,
                RouteId = deliveryDto.RouteId,
                DeliveryDate = deliveryDto.DeliveryDate,
                Status = deliveryDto.Status,
             
            };

            // Add the entity to the DbContext
            _appDbContext.Deliveries.Add(delivery);
            await _appDbContext.SaveChangesAsync();
        }
        public async Task<List<Delivery>> GetDeliveryList()
        {
            var deliveries = await _appDbContext.Deliveries
      .Include(d => d.DeliveryRoutes)   
      .Include(d => d.Shop)             
      .Include(d => d.DeliveryNote)     
      .ToListAsync();  

            return deliveries;
        }
     public async Task UpdateDelivery(UpdateDeliveryDto deliveryDto, int id)
{
    // Find the existing delivery by ID
    var existingDelivery = await _appDbContext.Deliveries.FindAsync(id);
    if (existingDelivery == null)
    {
        throw new Exception("Delivery not found");
    }

    // Update fields only if they are provided
    if (deliveryDto.ShopId.HasValue)
        existingDelivery.ShopId = deliveryDto.ShopId.Value;

    if (deliveryDto.RouteId.HasValue)
        existingDelivery.RouteId = deliveryDto.RouteId.Value;

    if (deliveryDto.DeliveryDate.HasValue)
        existingDelivery.DeliveryDate = deliveryDto.DeliveryDate.Value;

    if (!string.IsNullOrEmpty(deliveryDto.Status))
        existingDelivery.Status = deliveryDto.Status;

   

    // Save changes
    _appDbContext.Deliveries.Update(existingDelivery);
    await _appDbContext.SaveChangesAsync();
}


        public async Task DeleteDelivery(int id)
        {
            var delivery = await _appDbContext.Deliveries.FindAsync(id);
            if (delivery != null)
            {
                _appDbContext.Deliveries.Remove(delivery);
                await _appDbContext.SaveChangesAsync();
            }
        }
        public async  Task<Delivery> GetDeliveryById(int id){
            var delivery = await _appDbContext.Deliveries.FindAsync(id);
            return delivery;
        }
    }
}
