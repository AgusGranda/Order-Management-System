using AuthService.DTOs;
using AuthService.Interfaces;
using AuthService.Models;
using AuthService.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SendGrid.Helpers.Errors.Model;

namespace AuthService.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RoleController : Controller
    {

        private readonly IRoleService _roleService;
        public RoleController(IRoleService roleService) 
        {
            _roleService = roleService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Role>>> GetRoles()
        {
            try
            {
                var result = await _roleService.GetAllRoles();
                if(!result.Success)
                    return BadRequest(new { message = result.Message });
                return Ok(result.Data);

            }
            catch (Exception)
            {

                throw;
            }
        }

        [HttpGet("{idRole}")]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult<Role>> GetOneRole(int idRole)
        {
            try
            {
                var result = await _roleService.GetRole(idRole);
                if (!result.Success)
                    return BadRequest(new { message = result.Message });
                return Ok(result.Data);

            }
            catch (NotFoundException ex)
            {
                return NotFound(new { message = ex.Message });
            }
            catch (Exception)
            {

                throw;
            }
        }

        [HttpPost]
        public async Task<ActionResult<Role>> Create(RoleCreateDTO rol)
        {
            try
            {
                var result = await _roleService.CreateRole(rol);
                if (!result.Success)
                    return BadRequest(new { message = result.Message });
                return Ok(result.Data);
            }
            catch (Exception)
            {
                return BadRequest(new { message = "Error creating role" });
            }
        }

        
        [HttpPut]
        public async Task<ActionResult<Role>> Edit(int id, RoleUpdateDTO RoleEdited)
        {
            try
            {
                var result = await _roleService.UpdateRole(id, RoleEdited);
                if (!result.Success)
                    return BadRequest(new { message = result.Message });
                return Ok(result.Data);
            }
            catch (Exception)
            {
                return BadRequest(new { message = "Error updating role" });
            }
        }

        [HttpDelete]
        public async Task<ActionResult<Role>> Delete(int id)
        {
            try
            {
                var result = await _roleService.DeleteRole(id);
                if (!result.Success)
                    return BadRequest(new { message = result.Message });
                return Ok(result.Data);
            }
            catch(Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}
