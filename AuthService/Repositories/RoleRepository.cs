using AuthService.Data;
using AuthService.DTOs;
using AuthService.Interfaces;
using AuthService.Models;
using Microsoft.EntityFrameworkCore;

namespace AuthService.Repositories
{
    public class RoleRepository : IRoleRepository
    {
        private readonly AuthDbContext _context;
        public RoleRepository(AuthDbContext context) 
        {
            _context = context;

        }
        public async Task<List<Role>> GetAllRoles()
        {
            return await _context.Roles.Where(x=> x.Deleted == false).ToListAsync();
        }

        public async Task<Role?> GetRole(int id)
        {
            return await _context.Roles.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Role> CreateRole(Role role)
        {
            await _context.Roles.AddAsync(role);
            await _context.SaveChangesAsync();
            return role;

        }

        public async Task<Role> UpdateRole(Role roleUpdated)
        {
             _context.Roles.Update(roleUpdated);
            roleUpdated.UpdatedAt = DateTime.UtcNow;
            await _context.SaveChangesAsync();
            return roleUpdated;
        }
        public async Task<Role> DeleteRole(Role roleToDelete)
        {
            roleToDelete.Deleted = true;
            roleToDelete.DeletedAt = DateTime.UtcNow;
            _context.Roles.Update(roleToDelete);

            await _context.SaveChangesAsync();
            return roleToDelete;
        }

    }
}
