using AuthService.DTOs;
using AuthService.Models;

namespace AuthService.Interfaces
{
    public interface IAuthRepository
    {
        public Task<User> Login(LoginDTO userToLogin);
        public Task<User> Register(User userToRegister);
        public Task<User> UserExist(string email);
        public Task<User> UsernameExist(string username);
    }
}
