using FoodDevliveryServices.ModelDTO;

namespace FoodDevliveryServices.Services
{
    public interface IAuthenticationService
    {
        Task<RegistrationDTO> RegisterDriverAsync(RegistrationDTO request);
        Task<LogInResponseDTO> LoginDriverAsync(LogInDTO request);
    }
}
