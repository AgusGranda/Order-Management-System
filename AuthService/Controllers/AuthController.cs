using AuthService.DTOs;
using AuthService.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AuthService.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : Controller
    { 
        
        private readonly IAuthService _authService;
        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("login")]
        public async Task<ActionResult> Login([FromBody] LoginDTO UserToLogin)
        {
            try
            {
                
                var result = await _authService.Login(UserToLogin);

                if (!result.Success)
                    return BadRequest(result.Message);

                return Ok(result.Data);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }
        [HttpPost("register")]
        public async Task<ActionResult> Register([FromBody]RegisterDTO userToReister)
        {
            try
            {
                var result = await _authService.Register(userToReister);
                if(!result.Success)
                    return BadRequest(result.Message);

                return Ok(new { message = result.Message});
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }
        [HttpPost("logout")]
        public async Task<ActionResult> Logout(string email, string password)
        {
            try
            {
                // Simulate login logic
                return Ok(new { message = "Logout successful" });
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }
    }
}
