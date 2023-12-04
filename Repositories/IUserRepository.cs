using Repository;
using Entities;
using Dto;


namespace Repositories
{
    public interface IUserRepository
    {
        Task<User> GetUser(UserLoginDto userDto);
        Task<User> Post(User user);
        Task<User> UpdateUser(int id, User userToUpdate);
    }
}