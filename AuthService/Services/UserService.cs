using AuthService.DTOs;
using AuthService.Interfaces;
using AuthService.Models;
using AuthService.Tools;
using SendGrid.Helpers.Errors.Model;

namespace AuthService.Services
{
    public class UserService : IUserService
    {   
        private readonly IUserRepository _userRepository;
        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<OperationResult<List<User>>> GetUsers()
        {
            var result = await _userRepository.GetUsers();
            return new OperationResult<List<User>>
            {
                Success = true,
                Message = "Users retrieved successfully",
                Data = result
            };
        }
        public async Task<OperationResult<User>> GetUser(int id)
        {
            var user = await _userRepository.GetUser(id);
            if (user == null)
                throw new NotFoundException("User not found");
            return new OperationResult<User>
            {
                Success = true,
                Message = "User retrieved successfully",
                Data = user
            };
        }


        public async Task<OperationResult<User>> UpdateUser(int id, UserUpdateDTO userUpdated)
        {
            var userToUpdate = await _userRepository.GetUser(id);
            if (userToUpdate == null)
                throw new NotFoundException("User not found");



            await _userRepository.UpdateUser(userToUpdate);
            return new OperationResult<User>
            {
                Success = true,
                Message = "User updated successfully",
                Data = userToUpdate
            };

        }
        public async Task<OperationResult<User>> DesactivateUser(int id)
        {
            var userToDesactivate = await _userRepository.GetUser(id);
            if (userToDesactivate == null)
                throw new NotFoundException();

            await _userRepository.DesactivateUser(userToDesactivate);
            return new OperationResult<User>
            {
                Success = true,
                Message = "User desactivated successfully",
                Data = userToDesactivate
            };
        }

        public async Task<OperationResult<User>> DeleteUser(int userId)
        {
            var userToDelete = _userRepository.GetUser(userId);
            if (userToDelete == null)
                throw new NotFoundException("User not found");

            await _userRepository.DeleteUser(userToDelete.Result);
            return new OperationResult<User>
            {
                Success = true,
                Message = "User deleted successfully",
                Data = null
            };

        }
    }
}
