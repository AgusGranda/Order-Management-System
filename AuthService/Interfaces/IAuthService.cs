using AuthService.DTOs;
using AuthService.Models;
using AuthService.Tools;

namespace AuthService.Interfaces
{
    public interface IAuthService
    {
        public Task<OperationResult<TokenResponse>> Register(RegisterDTO userToRegister);
        public Task<OperationResult<TokenResponse>> Login(LoginDTO userToLogin);
        public Task<OperationResult<TokenResponse>> RefreshToken(string token, string refreshToken);
        public Task<OperationResult<object>> Logout(string token);

    }
}
