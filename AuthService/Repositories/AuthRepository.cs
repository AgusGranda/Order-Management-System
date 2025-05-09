using AuthService.Data;
using AuthService.DTOs;
using AuthService.Interfaces;
using AuthService.Models;
using Microsoft.EntityFrameworkCore;

namespace AuthService.Repositories
{
    public class AuthRepository : IAuthRepository
    {
        private readonly AuthDbContext _dbContext;
        public AuthRepository(AuthDbContext dbContext) 
        {
            _dbContext = dbContext;
        }

        public async Task<User> Login(LoginDTO userToLogin)
        {
            var userExist = await _dbContext.Users.FirstOrDefaultAsync(u => u.Email == userToLogin.Email);
            if(userExist != null && BCrypt.Net.BCrypt.Verify(userToLogin.Password, userExist.Password))
                return userExist;
            return null;

        }

        public async Task<User> Register(User userToRegister)
        {
            await _dbContext.Users.AddAsync(userToRegister);
            await _dbContext.SaveChangesAsync();
            return userToRegister;
        }

        public async Task <User> UserExist(string email)
        {
            return await _dbContext.Users.FirstOrDefaultAsync(u => u.Email == email);
        }
        public async Task<User> UsernameExist(string username)
        {
            return await _dbContext.Users.FirstOrDefaultAsync(u => u.Username == username);
        }
    }
}
