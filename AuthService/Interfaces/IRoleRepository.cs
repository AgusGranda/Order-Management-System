using AuthService.Models;

namespace AuthService.Interfaces
{
    public interface IRoleRepository
    {
        public Task<List<Role>> GetAllRoles();
        public Task<Role?> GetRole(int id);
        public Task<Role> CreateRole(Role role);
        public Task<Role> UpdateRole(Role roleToUpdate);
        public Task<Role> DeleteRole (Role roleToDelete);
    }
}
