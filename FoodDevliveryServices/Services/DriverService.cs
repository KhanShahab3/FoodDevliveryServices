using FoodDevliveryServices.DataBaseContext;
using FoodDevliveryServices.ModelDTO;
using FoodDevliveryServices.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Identity.Data;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace FoodDevliveryServices.Services
{
    public class DriverService : IDriverService
    {
        private readonly AppDbContext _appDbContext;
     
        public DriverService(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
           
        }
     

       

        public async Task AddDriver(CreateDriverDTO driverDto)
        {
        if (driverDto == null) throw new ArgumentNullException(nameof(driverDto));
            var driver = new Drivers
            {
                FullName= driverDto.FullName,
                Email= driverDto.Email,
             
                CreatedAt=DateTime.Now,
               

            };
            _appDbContext.Drivers.Add(driver);
            await _appDbContext.SaveChangesAsync();
        }

        public async Task<List<Drivers>> GetDriverList()
        {
            var driversWithMultipleRoutes = await _appDbContext.Drivers
                .Include(d => d.DeliveryRoutes) // Include related DeliveryRoutes
                .Where(d => d.DeliveryRoutes.Count > 1) // Filter drivers with more than one route
                .ToListAsync(); 

            return driversWithMultipleRoutes;
        }

        public async Task UpdateDriver(Drivers driver, int id)
        {
            var existingDriver = await _appDbContext.Drivers.FindAsync(id);
            if (existingDriver != null)
            {
                existingDriver.FullName = driver.FullName;
                existingDriver.Email = driver.Email;
                existingDriver.Password = driver.Password;
                existingDriver.UpdatedAt = DateTime.Now;
                

                // Update other relevant fields here

                _appDbContext.Drivers.Update(existingDriver);
                await _appDbContext.SaveChangesAsync();
            }
        }
        public async Task DeleteDriver(int id)
        {
            var driver = await _appDbContext.Drivers.FindAsync(id);
            if (driver != null)
            {
                _appDbContext.Drivers.Remove(driver);
                await _appDbContext.SaveChangesAsync();
            }
        }
        public async Task<Drivers> GetDriverById(int id)
        {
            var driver = await _appDbContext.Drivers.FindAsync(id);
            return driver;
        }
    }
    
}
