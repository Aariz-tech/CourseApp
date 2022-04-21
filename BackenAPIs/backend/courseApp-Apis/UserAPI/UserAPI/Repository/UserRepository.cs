using System.Collections.Generic;
using UserAPI.Models;
using UserAPI.Context;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace UserAPI.Repository
{
    public class UserRepository : IUserRepository
    {
        readonly UserDbContext _userDbContext;
        public UserRepository(UserDbContext userDbContext)
        {

            _userDbContext = userDbContext;
        }
        public bool BlockAndUnBlockUser(bool blockUnBlockUser,User user)
        {
            user.IsBlocked = blockUnBlockUser;
            _userDbContext.Entry<User>(user).State = EntityState.Modified;
            int numberOfRows = _userDbContext.SaveChanges();
            if(numberOfRows == 1)
            {
                return true;
            }
            else
            {
                return false;
            }
            
        }

        public bool DeleteUser(User user)
        {
            _userDbContext.Users.Remove(user);
            _userDbContext.SaveChanges();
            return true;
        }

        public bool EditUser(User user)
        {
            _userDbContext.Users.Update(user);
            _userDbContext.SaveChanges();
            return true;
        }

        public List<User> GetAllUsers()
        {
            return _userDbContext.Users.Where(u=>u.IsBlocked==false).ToList();
        }

        public User GetUserById(int id)
        {
            return _userDbContext.Users.Where(u => u.Id == id).FirstOrDefault();
        }

        public User Login(string userName, string password)
        {
            return _userDbContext.Users.Where(u => u.UserName == userName && u.Password == password).FirstOrDefault();
        }

        public bool RegisterUser(User user)
        {
            _userDbContext.Users.Add(user);
            _userDbContext.SaveChanges();
            return true;
        }
    }
}
