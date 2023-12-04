using Repository;
using Entities;
using Dto;


namespace Services
{
    public interface IUserService
    {
        Task<int> check(string password);
        Task<User> GetUser(UserLoginDto userDto);
        Task<User> Post(User user);
        Task<User> UpdateUser(int id, User userToUpdate);
    }
}