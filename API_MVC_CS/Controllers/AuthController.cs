using Microsoft.AspNetCore.Mvc;
using MVC_CS_API.DTO;
using MVC_CS_API.Services;

namespace MVC_CS_API.Controllers
{
    [ApiController]
    [Route("/api/auth")]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            this._authService = authService;
        }

        [HttpPost("login")]
        public IActionResult Login([FromBody] AuthUserDTO user)
        {
            try
            {
                return Ok(_authService.Login(user));
            }
            catch (UnauthorizedAccessException exAuth)
            {
                return Unauthorized(exAuth);
            }
            catch (BadHttpRequestException exBadRequest)
            {
                return BadRequest(exBadRequest);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpPost("register")]
        public IActionResult Register([FromBody] RegisterUserDTO user)
        {
            try
            {
                return Ok(_authService.Register(user));
            }
            catch (BadHttpRequestException exBadRequest)
            {
                return BadRequest(exBadRequest);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
    }
}