using AuthService.Data;
using AuthService.Interfaces;
using AuthService.Models;
using Microsoft.EntityFrameworkCore;

namespace AuthService.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly AuthDbContext _context;

        public UserRepository(AuthDbContext context)
        {
            _context = context;
        }

        public async Task<List<User>> GetUsers()
        {
            return await _context.Users.Where(x => x.Deleted == false).ToListAsync();   
        }
        public async Task<User?> GetUser(int id)
        {
            return await _context.Users.FirstOrDefaultAsync(x => x.Id == id && !x.Deleted);
        }

        public async Task<User?> GetUserByEmail(string email)
        {
            return await _context.Users.FirstOrDefaultAsync(x => x.Email == email && x.Deleted == false);
        }


        public async Task<User> UpdateUser(User userUpdated)
        {

            _context.Users.Update(userUpdated);
            await _context.SaveChangesAsync();
            return userUpdated;

        }
        public async Task<User> DesactivateUser(User userToDesactivate)
        {
            userToDesactivate.Desactivated = true;
            userToDesactivate.UpdatedAt = DateTime.UtcNow;

            _context.Users.Update(userToDesactivate);
            await _context.SaveChangesAsync();
            return userToDesactivate;
        }
        public async Task<User> DeleteUser(User userToDelete)
        {

            userToDelete.Deleted = true;
            userToDelete.DeletedAt = DateTime.UtcNow;
            _context.Users.Update(userToDelete);

            await _context.SaveChangesAsync();
            return userToDelete;
        }
    }
}
