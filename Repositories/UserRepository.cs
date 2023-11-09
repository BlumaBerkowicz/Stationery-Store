using Entities;
using Microsoft.EntityFrameworkCore;
using System.Text.Json;

namespace Repositories
{
    public class UserRepository :  IUserRepository
    {
        private readonly AdoNetContext _DbContext;
        public UserRepository(AdoNetContext dbContext)
        {
            _DbContext = dbContext;
        }

        public async Task<User> GetUserByUserNameAndPassword(string userName = "", string password ="")
        {
            return await _DbContext.Users.Where(user => user.Email == userName && user.Password == password).FirstOrDefaultAsync();

            //using (StreamReader reader = System.IO.File.OpenText(FilePath))
            //{
            //    string? currentUserInFile;
            //    while ((currentUserInFile = reader.ReadLine()) != null)
            //    {
            //        User user = JsonSerializer.Deserialize<User>(currentUserInFile);
            //        if (user.Email == userName && user.Password == password)
            //            return user;
            //    }
            //}
            //return null;

        }
        public async Task<User> UpdateUser(int id, User userToUpdate)
        {
            userToUpdate.UserId = id;
            _DbContext.Users.Update(userToUpdate);
            await _DbContext.SaveChangesAsync();
            return userToUpdate;


            //string textToReplace = string.Empty;
            //using (StreamReader reader = System.IO.File.OpenText(FilePath))
            //{
            //    string currentUserInFile;
            //    while ((currentUserInFile = reader.ReadLine()) != null)
            //    {

            //        User user = JsonSerializer.Deserialize<User>(currentUserInFile);
            //        if (user.UserId == id)
            //            textToReplace = currentUserInFile;
            //    }
            //}
            //if (textToReplace != string.Empty)
            //{
            //    string text = System.IO.File.ReadAllText(FilePath);
            //    text = text.Replace(textToReplace, JsonSerializer.Serialize(userToUpdate));
            //    System.IO.File.WriteAllText(FilePath, text);
            //}
        }
        public async Task<User> Post(User user)
        {
            _DbContext.AddAsync(user);
            _DbContext.SaveChangesAsync();
            //int numberOfUsers = System.IO.File.ReadLines(FilePath).Count();
            //user.UserId = numberOfUsers + 1;
            //string userJson = JsonSerializer.Serialize(user);
            //System.IO.File.AppendAllText(FilePath, userJson + Environment.NewLine);
            return user;
        }
    }
}