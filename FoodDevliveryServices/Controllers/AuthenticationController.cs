using FoodDevliveryServices.ModelDTO;
using FoodDevliveryServices.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FoodDevliveryServices.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly IAuthenticationService _authenticationService;
        public AuthenticationController(IAuthenticationService authenticationService)
        {
            _authenticationService = authenticationService;
        }
        [HttpPost("register")]
        public async Task<IActionResult> Register(RegistrationDTO request)
        {
            var user = await _authenticationService.RegisterDriverAsync(request);
            return Ok(user);
        }
        [HttpPost("login/driver")]
        public async Task<IActionResult> LoginDriver(LogInDTO request)
        {
            var token = await _authenticationService.LoginDriverAsync(request);
           
            return Ok(new { Token = token });
        }
    }
}
