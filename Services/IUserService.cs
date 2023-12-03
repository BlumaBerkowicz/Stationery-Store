using Repository;

namespace Services
{
    public interface IUserService
    {
        Task<int> check(string password);
        Task<User> GetUserByUserNameAndPassword(string UserName, string Password);
        Task<User> Post(User user);
        Task<User> UpdateUser(int id, User userToUpdate);
    }
}