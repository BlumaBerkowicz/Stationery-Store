using Entities;

namespace Services
{
    public interface IUserService
    {
        int check(string password);
        User GetUserByUserNameAndPassword(string UserName, string Password);
        User Post(User user);
        User UpdateUser(int id, User userToUpdate);
    }
}