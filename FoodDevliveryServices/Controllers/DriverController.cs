using FoodDevliveryServices.ModelDTO;
using FoodDevliveryServices.Models;
using FoodDevliveryServices.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity.Data;
using Microsoft.AspNetCore.Mvc;

namespace FoodDevliveryServices.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DriverController : ControllerBase
    {
        private readonly IDriverService _driverService;
        public DriverController(IDriverService driverService)
        {
            _driverService = driverService;
        }

       
       
        [HttpGet]
        public async Task<ActionResult<List<Drivers>>> GetAllDrivers()
        {
            var drivers = await _driverService.GetDriverList();
            if (drivers.Count == 0)
                return new List<Drivers>();
            return Ok(drivers);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<Drivers>> GetDriverById(int id)
        {
            var driver = await _driverService.GetDriverById(id);
            if (driver == null)
                return NotFound();
            return Ok(driver);
        }
        [HttpPost]
        public async Task<ActionResult> AddDelivery(CreateDriverDTO driver)
        {
            await _driverService.AddDriver(driver);
            return Ok("Inventory Created....!");
        }
        [HttpPut("{id}")]
        public async Task<ActionResult<Drivers>> UpdateDelivery(Drivers driver, int id)
        {
            await _driverService.UpdateDriver(driver, id);


            return Ok("Inventory Updated......!");
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteDriver(int id)
        {
            await _driverService.DeleteDriver(id);
            return Ok("Inventory Deleted.....!");
        }
    }
}
