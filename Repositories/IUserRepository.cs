using Repository;
using Entities;

namespace Repositories
{
    public interface IUserRepository
    {
        Task<User> GetUserByUserNameAndPassword(string userName = "", string password = "");
        Task<User> Post(User user);
        Task<User> UpdateUser(int id, User userToUpdate);
    }
}