using Entities;

namespace Repositories
{
    public interface IUserRepository
    {
        User GetUserByUserNameAndPassword(string userName = "", string password = "");
        User Post(User user);
        User UpdateUser(int id, User userToUpdate);
    }
}