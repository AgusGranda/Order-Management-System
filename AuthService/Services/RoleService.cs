using AuthService.Interfaces;
using AuthService.Models;
using AuthService.Tools;
using SendGrid.Helpers.Errors.Model;

namespace AuthService.Services
{
    public class RoleService : IRoleService
    {
        private readonly IRoleRepository  _roleRepository; 
        public RoleService( IRoleRepository roleRepository)
        {
            _roleRepository = roleRepository;
        }
        public async Task<OperationResult<List<Role>>> GetAllRoles()
        {
                 var roles = await _roleRepository.GetAllRoles();
                return new OperationResult<List<Role>>
                {
                    Success = true,
                    Message = "Roles retrieved successfully",
                    Data = roles
                };
        }

        public async Task<OperationResult<Role>> GetRole(int id)
        {
          
            var rol = await _roleRepository.GetRole(id);
            if (rol == null)
                throw new NotFoundException("");
                   
                return new OperationResult<Role>
                {
                    Success = true,
                    Message = "Role retrieved successfully",
                    Data = rol
                };
        }

        public async Task<OperationResult<Role>> CreateRole(Role role)
        {
            await _roleRepository.CreateRole(role);
            return new OperationResult<Role>
            {
                Success = true,
                Message = "Role created successfully",
                Data = role
            };
        }


        public async Task<OperationResult<Role>> UpdateRole(int id, Role roleUpdated)
        {
            var roleToUpdate = await _roleRepository.GetRole(id);
            if (roleToUpdate == null)
                throw new NotFoundException("");

            await _roleRepository.UpdateRole(roleUpdated);
            return new OperationResult<Role>
            {
                Success = true,
                Message = "Role updated successfully",
                Data = roleUpdated
            };
        }
        public async Task<OperationResult<Role>> DeleteRole(int id)
        {
            var roleToDelete = await _roleRepository.GetRole(id);
            if (roleToDelete == null)
                throw new NotFoundException("");

            await _roleRepository.DeleteRole(roleToDelete);
            return new OperationResult<Role>
            {
                Success = true,
                Message = "Role deleted successfully",
                Data = null
            };
        }
    }
}
