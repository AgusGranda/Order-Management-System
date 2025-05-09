using AuthService.Interfaces;
using AuthService.Models;
using AuthService.Tools;

namespace AuthService.Services
{
    public class UserService : IUserService
    {
        public Task<OperationResult<List<User>>> GetUsers()
        {
            throw new NotImplementedException();
        }
        public Task<OperationResult<User>> GetUser(int id)
        {
            throw new NotImplementedException();
        }


        public Task<OperationResult<User>> UpdateUser(int id, User userToUpdate)
        {
            throw new NotImplementedException();
        }
        public Task<OperationResult<User>> DesactivateUser(int id)
        {
            throw new NotImplementedException();
        }

        public Task<OperationResult<User>> DeleteUser(int userId)
        {
            throw new NotImplementedException();
        }
    }
}
