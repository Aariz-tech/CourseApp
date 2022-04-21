using UserAPI.Models;
using System.Collections.Generic;
namespace UserAPI.Repository
{
    public interface IUserRepository
    {
        List<User> GetAllUsers();
        bool RegisterUser(User user);
        User GetUserById(int id);
        bool DeleteUser(User user);
        bool BlockAndUnBlockUser(bool blockUnBlockUser, User userExist);
        bool EditUser(User user);
        User Login(string userName, string password);
    }
}
