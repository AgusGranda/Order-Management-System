using AuthService.DTOs;
using AuthService.Interfaces;
using AuthService.Models;
using AuthService.Tools;
using AutoMapper;
using SendGrid.Helpers.Errors.Model;

namespace AuthService.Services
{
    public class RoleService : IRoleService
    {
        private readonly IRoleRepository  _roleRepository; 
        private readonly IMapper _mapper;
        public RoleService( IRoleRepository roleRepository, IMapper mapper)
        {
            _roleRepository = roleRepository;
            _mapper = mapper;
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

        public async Task<OperationResult<Role>> CreateRole(RoleCreateDTO role)
        {
            try
            {
                var newRole = _mapper.Map<Role>(role);  
                await _roleRepository.CreateRole(newRole);
                return new OperationResult<Role>
                {
                    Success = true,
                    Message = "Role created successfully",
                    Data = newRole
                };

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }


        public async Task<OperationResult<Role>> UpdateRole(int id, RoleUpdateDTO roleUpdated)
        {
            var roleToUpdate = await _roleRepository.GetRole(id);
            if (roleToUpdate == null)
                throw new NotFoundException("");

            _mapper.Map(roleUpdated, roleToUpdate);
            roleToUpdate.UpdatedAt = DateTime.UtcNow;

            await _roleRepository.UpdateRole(roleToUpdate);
            return new OperationResult<Role>
            {
                Success = true,
                Message = "Role updated successfully",
                Data = roleToUpdate
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
