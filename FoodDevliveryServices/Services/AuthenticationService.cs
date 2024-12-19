using FoodDevliveryServices.DataBaseContext;
using FoodDevliveryServices.ModelDTO;
using Microsoft.EntityFrameworkCore;

namespace FoodDevliveryServices.Services
{
    public class AuthenticationService:IAuthenticationService
    {
        private readonly AppDbContext _appDbContext;
        private readonly TokenService _tokenService;
        public AuthenticationService(AppDbContext appDbContext, TokenService tokenService)
        {
            _appDbContext = appDbContext;
            _tokenService = tokenService;
        }

        public async Task<LogInResponseDTO> LoginDriverAsync(LogInDTO request)
        {
            var driver = await _appDbContext.Drivers.FirstOrDefaultAsync(d => d.Email == request.Email && d.Password == request.Password);

            if (driver == null)
                throw new UnauthorizedAccessException("Invalid credentials");

            var token= _tokenService.GenerateToken(driver.Id,driver.Email);
            var result = new LogInResponseDTO
            {
                token = token,
                roleNme = driver.Role
            };
            return result;
        }
        public async Task<RegistrationDTO> RegisterDriverAsync(RegistrationDTO request)
        {
            var existingDriver = await _appDbContext.Drivers.FirstOrDefaultAsync(d => d.Email == request.Email);
            if (existingDriver != null)
                throw new Exception("Driver already registered");

            var newDriver = new Drivers
            {
                FullName = request.FullName,
                Email = request.Email,
                Password = request.Password, // For simplicity, no hashing
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow,
                Role = request.Role,
              
            };

            _appDbContext.Drivers.Add(newDriver);
            await _appDbContext.SaveChangesAsync();
            var result = new RegistrationDTO
            {
                FullName = newDriver.FullName,
                Email = newDriver.Email,
                Password = newDriver.Password,
                Role = newDriver.Role,
            };

            return result;
        }
    }
}
