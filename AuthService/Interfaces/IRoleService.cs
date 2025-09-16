using AuthService.DTOs;
using AuthService.Models;
using AuthService.Tools;

namespace AuthService.Interfaces
{
    public interface IRoleService
    {
        public Task<OperationResult<List<Role>>> GetAllRoles();
        public Task<OperationResult<Role>> GetRole(int id);
        public Task<OperationResult<Role>> CreateRole(RoleCreateDTO role);
        public Task<OperationResult<Role>> UpdateRole(int id, RoleUpdateDTO roleToUpdate);
        public Task<OperationResult<Role>> DeleteRole(int id);

    }
}
