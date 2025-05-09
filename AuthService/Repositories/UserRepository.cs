using AuthService.Data;
using AuthService.Interfaces;
using AuthService.Models;

namespace AuthService.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly AuthDbContext _context;

        public UserRepository(AuthDbContext context)
        {
            _context = context;
        }

        public Task<List<User>> GetUsers()
        {
            throw new NotImplementedException();
        }
        public Task<User> GetUser(int id)
        {
            throw new NotImplementedException();
        }

        public Task<object> GetUserByEmail(string email)
        {
            throw new NotImplementedException();
        }


        public Task<User> UpdateUser(User userToUpdate)
        {
            throw new NotImplementedException();
        }
        public Task<User> DesactivateUser(User userToDesactivate)
        {
            throw new NotImplementedException();
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
