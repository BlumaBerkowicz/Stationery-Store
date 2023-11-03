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

        public User GetUserByUserNameAndPassword(string UserName, string Password)
        {
            return userRepository.GetUserByUserNameAndPassword(UserName, Password);
        }
        public User UpdateUser(int id, User userToUpdate)
        {
            if (check(userToUpdate.password) < 2)
                return null;
            return userRepository.UpdateUser(id, userToUpdate);
        }
        public User Post(User user)
        {
            if (check(user.password) < 2)
                return null;
            return userRepository.Post(user);
        }
        public int check(string password)
        {
            return Zxcvbn.Core.EvaluatePassword(password).Score;

        }

    }

}