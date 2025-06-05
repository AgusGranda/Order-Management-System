using AuthService.Models;

namespace AuthService.Interfaces
{
    public interface IUserRepository
    {
        public Task<List<User>> GetUsers();
        public Task<User?> GetUser(int id);
        public Task<User?> GetUserByEmail(string email);
        public Task<User> UpdateUser(User userToUpdate);
        public Task<User> DesactivateUser(User userToDesactivate);
        public Task<User> DeleteUser(User userToDelete);
    }
}
