using System.Collections.Generic;
using UserAPI.Models;
using UserAPI.Repository;
using UserAPI.Exceptions;

namespace UserAPI.Services
{
    public class UserService : IUserService
    {
        readonly IUserRepository _userRepository;
        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public bool BlockAndUnBlockUser(int id,bool blockUnBlockUser)
        {
            User userExist = _userRepository.GetUserById(id);
            if(userExist == null)
            {
                return false;
            }
            else
            {
                return _userRepository.BlockAndUnBlockUser(blockUnBlockUser,userExist);
            }
            
        }

        public bool DeleteUser(int id)
        {
            User userExist = _userRepository.GetUserById(id);
            if(userExist == null)
            {
                return false;
            }
            else
            {
                return _userRepository.DeleteUser(userExist);
            }
            
        }

        public bool EditUser(int id, User user)
        {
            
                user.Id = id;
                return _userRepository.EditUser(user);
            

        }

        public List<User> GetAllUsers()
        {
            return _userRepository.GetAllUsers();
        }

        public User GetUserById(int id)
        {
            return _userRepository.GetUserById(id);
        }

        public User Login(LoginUser loginUser)
        {
            User user =  _userRepository.Login(loginUser.UserName, loginUser.Password);
            if(user == null)
            {
                throw new UserNotFoundException("No Details Match Please Try again");
            }
            else
            {
                return user;
            }
        }

        public bool RegisterUser(User user)
        {
            User userExist = _userRepository.GetUserById(user.Id);
            if(userExist == null)
            {
                return _userRepository.RegisterUser(user);
            }
            return false;
            
        }
    }
}
