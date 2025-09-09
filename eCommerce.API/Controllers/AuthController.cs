using eCommerce.Core.DTO;
using Microsoft.AspNetCore.Mvc;

using eCommerce.Core.ServiceContract;

namespace eCommerce.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IUserService _userService;
        public AuthController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginRequest loginRequest)
        {
            if (loginRequest == null) {
                return BadRequest();
            }
            var response = await _userService.Login(loginRequest);
            if (response == null) {
                return Unauthorized();

            }
            return Ok(response);
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(RegisterRequest registerRequest)
        {
            if (registerRequest == null) {
                return BadRequest();
            }

            var response  = await _userService.Register(registerRequest);
            if(response is null)
            {
                return BadRequest();
            }

            return Ok(response);
        }
    }
}
