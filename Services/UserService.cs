using Repository;
using Repositories;
using Zxcvbn;
using Entities;
using Dto;

namespace Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository userRepository;
        public UserService(IUserRepository _userRepository)
        {
            userRepository = _userRepository;
        }

        public async Task<User> GetUser(UserLoginDto userDto)
        {
            return await userRepository.GetUser(userDto);
        }
        public async Task<User> UpdateUser(int id, User userToUpdate)
        {
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