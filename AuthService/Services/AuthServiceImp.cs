using AuthService.DTOs;
using AuthService.Interfaces;
using AuthService.Models;
using AuthService.Tools;
using AutoMapper;

namespace AuthService.Services
{
    public class AuthServiceImp : IAuthService
    {
        private readonly IAuthRepository _authRepository;
        private readonly JwtTokenGenerator _jwtTokenGenerator;
        private readonly IMapper _mapper;

        public AuthServiceImp( IAuthRepository authRepository, JwtTokenGenerator jwtTokenGenerator,IMapper mapper )
        {
            _mapper = mapper;
            _authRepository = authRepository;
            _authRepository = authRepository;
            _jwtTokenGenerator = jwtTokenGenerator;
        }

        public async Task<OperationResult<TokenResponse>> Login(LoginDTO userToLogin)
        {
            var result = await _authRepository.Login(userToLogin);

            if (result == null)
            {
                return (new OperationResult<TokenResponse>
                {
                    Success = false,
                    Message = "Invalid credentials"
                });
            }


            var token = _jwtTokenGenerator.GenerateToken(result);
            return (new OperationResult<TokenResponse>
            {
                Success = true,
                Message = "Login successful",
                Data = token
            });

        }

        public async Task<OperationResult<TokenResponse>> Register(RegisterDTO userToRegister)
        {

            // Verificamos que no exista el Username (Decision de negocio)

            var usernameExist = await _authRepository.UsernameExist(userToRegister.Username);
            if (usernameExist != null)
                return (new OperationResult<TokenResponse>
                {
                    Success = false,
                    Message = "Username already exists"
                });

            // Verificamos que no exista el Email

            var userExist = await _authRepository.UserExist(userToRegister.Email);
            if(userExist != null)
                return (new OperationResult<TokenResponse>
                {
                    Success = false,
                    Message = "User already exists"
                });


            // Mapeamos los datos para crear un nuevo usuario y si todo esta Ok Lo guardamos en la base de datos
            User newUser = _mapper.Map<User>(userToRegister);
            newUser.Password = BCrypt.Net.BCrypt.HashPassword(userToRegister.Password);
            var result = await _authRepository.Register(newUser);
            if(result != null)
            {
                return (new OperationResult<TokenResponse>
                {
                    Success = true,
                    Message = "User created"
                });
            }


            return (new OperationResult<TokenResponse>
            {
                Success = false,
                Message = "Error creating user"
            });

        }

        public Task<OperationResult<object>> Logout(string token)
        {
            throw new NotImplementedException();
        }

        public Task<OperationResult<TokenResponse>> RefreshToken(string token, string refreshToken)
        {
            throw new NotImplementedException();
        }

    }
}
