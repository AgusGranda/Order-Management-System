using AuthService.Models;
using AuthService.Tools;

namespace AuthService.Interfaces
{
    public interface IUserService
    {

        public Task<OperationResult<List<User>>> GetUsers();
        public Task<OperationResult<User>> GetUser(int id);
        public Task<OperationResult<User>> UpdateUser(int id, User userUpdated);
        public Task<OperationResult<User>> DesactivateUser(int id);
        public Task<OperationResult<User>> DeleteUser(int id);

    }
}
