using FoodDevliveryServices.ModelDTO;

namespace FoodDevliveryServices.Services
{
    public interface IDriverService
    {
        Task AddDriver(CreateDriverDTO driver);
        Task<List<Drivers>> GetDriverList();
        Task DeleteDriver(int id);
        Task UpdateDriver(Drivers driver, int id);
        Task<Drivers> GetDriverById(int id);

    }
}













