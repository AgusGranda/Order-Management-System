using AuthService.Models;
using AuthService.Tools;

namespace AuthService.Interfaces
{
    public interface IRoleService
    {
        public Task<OperationResult<List<Role>>> GetAllRoles();
        public Task<OperationResult<Role>> GetRole(int id);
        public Task<OperationResult<Role>> CreateRole(Role role);
        public Task<OperationResult<Role>> UpdateRole(int id, Role roleToUpdate);
        public Task<OperationResult<Role>> DeleteRole(int id);

    }
}
