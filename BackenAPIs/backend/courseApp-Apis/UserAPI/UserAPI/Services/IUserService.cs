using System.Collections.Generic;
using UserAPI.Models;

namespace UserAPI.Services
{
    public interface IUserService
    {
        List<User> GetAllUsers();
        bool RegisterUser(User user);
        User GetUserById(int id);
        bool DeleteUser(int id);
        bool BlockAndUnBlockUser(int id,bool blockUnBlockUser);
        bool EditUser(int id, User user);
        User Login(LoginUser loginUser);
    }
}
