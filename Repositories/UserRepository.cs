using Repository;
using Microsoft.EntityFrameworkCore;
using Repositories;
using Repository;
using System.Text.Json;
using Entities;

namespace Repositories
{
    public class UserRepository :  IUserRepository
    {
        private readonly MyStoreDBContext _DbContext;
        public UserRepository(MyStoreDBContext dbContext)
        {
            _DbContext = dbContext;
        }

        public async Task<User> GetUserByUserNameAndPassword(string userName = "", string password ="")
        {
            return await _DbContext.Users.Where(user => user.Email == userName && user.Password == password).FirstOrDefaultAsync();

        }
        public async Task<User> UpdateUser(int id, User userToUpdate)
        {
            userToUpdate.UserId = id;
            _DbContext.Users.Update(userToUpdate);
            await _DbContext.SaveChangesAsync();
            return userToUpdate;
        }
        public async Task<User> Post(User user)
        {
            _DbContext.Users.AddAsync(user);
            _DbContext.SaveChangesAsync();
            return user;
        }
    }
}
