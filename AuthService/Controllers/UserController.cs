using AuthService.DTOs;
using AuthService.Interfaces;
using AuthService.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SendGrid.Helpers.Errors.Model;

namespace AuthService.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : Controller
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<User>>> Get()
        {
            var result = await _userService.GetUsers();
            if (!result.Success)
                return BadRequest(new { message = result.Message });
            return Ok(result.Data);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<User>> Get(int id)
        {
            try
            {
                var result = await _userService.GetUser(id);
                if (!result.Success)
                    return BadRequest(new { message = result.Message });
                return Ok(result.Data);
            }
            catch (NotFoundException ex)
            {
                return NotFound(new { message = ex.Message });
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<User>> Update(int id, UserUpdateDTO userUpdated)
        {
            try
            {
                var result = await _userService.UpdateUser(id, userUpdated);
                if (!result.Success)
                    return BadRequest(new { message = result.Message });
                return Ok(result.Data);
            }
            catch (NotFoundException ex)
            {
                return NotFound(new { message = ex.Message });
            }
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult<User>> Desactivate(int id)
        {
            try
            {
                var result = await _userService.DesactivateUser(id);
                if (!result.Success)
                    return BadRequest(new { message = result.Message });
                return Ok(result.Data);
            }
            catch (NotFoundException ex)
            {
                return NotFound(new { message = ex.Message });
            }

        }
    }
}
