using Entities;
using Repositories;
using Zxcvbn;
namespace Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository userRepository;
        public UserService(IUserRepository _userRepository)
        {
            userRepository = _userRepository;
        }

        public async Task<User> GetUserByUserNameAndPassword(string UserName, string Password)
        {
            return await userRepository.GetUserByUserNameAndPassword(UserName, Password);
        }
        public async Task<User> UpdateUser(int id, User userToUpdate)
        {
            if (await check(userToUpdate.Password) < 2)//duplicate lines!
            if (await check(userToUpdate.Password) < 2)
                return null;
            return await userRepository.UpdateUser(id, userToUpdate);
        }
        public async Task<User> Post(User user)
        {
            if (await check(user.Password) < 2)
                return null;
            return await userRepository.Post(user);
        }
        public async Task<int> check(string password)
        {
            return Zxcvbn.Core.EvaluatePassword(password).Score;
        }
    }
}