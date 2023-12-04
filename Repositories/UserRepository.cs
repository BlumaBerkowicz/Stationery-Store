using Microsoft.EntityFrameworkCore;
using Repositories;
using Repository;
using System.Text.Json;
using Entities;
using Dto;

namespace Repositories
{
    public class UserRepository :  IUserRepository
    {
        private readonly MyStoreDbContext _DbContext;
        public UserRepository(MyStoreDbContext dbContext)
        {
            _DbContext = dbContext;
        }

        public async Task<User> GetUser(UserLoginDto userDto )
        {
            return await _DbContext.Users.Where(user => user.Email == userDto.Email && user.Password == userDto.Password).FirstOrDefaultAsync();

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
            await _DbContext.Users.AddAsync(user);
           await _DbContext.SaveChangesAsync();
            return user;
        }
    }
}
